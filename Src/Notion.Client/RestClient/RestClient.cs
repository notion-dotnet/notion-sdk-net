using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Notion.Client.Extensions;
using Notion.Client.http;

namespace Notion.Client
{
    public class RestClient : IRestClient
    {
        private readonly ClientOptions _options;

        internal static readonly JsonSerializerSettings DefaultSerializerSettings = new()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() }
        };

        private readonly HttpClient _httpClient;
        private readonly IRetryPolicy _retryPolicy;
        private readonly TimeSpan? _timeout;

        public RestClient(ClientOptions options)
        {
            _options = MergeOptions(options);
            _retryPolicy = options.RetryPolicy;
            _timeout = options.Timeout;
            _httpClient = ResolveHttpClient(options.HttpClient, _options.BaseUrl);
        }

        /// <summary>
        /// Returns the <see cref="HttpClient"/> to use for all requests.
        /// <para>
        /// When <paramref name="provided"/> is supplied it is used as-is (only <c>BaseAddress</c> is set
        /// if absent). The caller owns the lifetime of the provided client.
        /// </para>
        /// <para>
        /// When <paramref name="provided"/> is <c>null</c>, a default pipeline is built:
        /// <c>LoggingHandler → HttpClientHandler</c>.
        /// </para>
        /// </summary>
        private static HttpClient ResolveHttpClient(HttpClient provided, string baseUrl)
        {
            if (provided != null)
            {
                if (provided.BaseAddress == null)
                {
                    provided.BaseAddress = new Uri(baseUrl);
                }

                return provided;
            }

            var pipeline = new LoggingHandler { InnerHandler = new HttpClientHandler() };

            return new HttpClient(pipeline) { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<T> GetAsync<T>(
            string uri,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null,
            JsonSerializerSettings serializerSettings = null,
            CancellationToken cancellationToken = default)
        {
            var response = await SendAsync(uri, HttpMethod.Get, queryParams, headers,
                cancellationToken: cancellationToken);

            return await response.ParseStreamAsync<T>(serializerSettings);
        }

        public async Task<T> PostAsync<T>(
            string uri,
            object body,
            IEnumerable<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headers = null,
            JsonSerializerSettings serializerSettings = null,
            IBasicAuthenticationParameters basicAuthenticationParameters = null,
            CancellationToken cancellationToken = default)
        {
            void AttachContent(HttpRequestMessage httpRequest)
            {
                if (body == null)
                {
                    return;
                }

                var jsonObjectString = JsonConvert.SerializeObject(body, DefaultSerializerSettings);
                httpRequest.Content = new StringContent(jsonObjectString, Encoding.UTF8, "application/json");
            }

            var response = await SendAsync(
                uri,
                HttpMethod.Post,
                queryParams,
                headers,
                AttachContent,
                basicAuthenticationParameters,
                cancellationToken
            );

            return await response.ParseStreamAsync<T>(serializerSettings);
        }

        public async Task<T> PostAsync<T>(
            string uri,
            ISendFileUploadFormDataParameters formData,
            IEnumerable<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headers = null,
            JsonSerializerSettings serializerSettings = null,
            IBasicAuthenticationParameters basicAuthenticationParameters = null,
            CancellationToken cancellationToken = default)
        {
            void AttachContent(HttpRequestMessage httpRequest)
            {
                var fileContent = new StreamContent(formData.File.Data);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(formData.File.ContentType);

                var form = new MultipartFormDataContent
                {
                    { fileContent, "file", formData.File.FileName }
                };

                if (!string.IsNullOrEmpty(formData.PartNumber))
                {
                    form.Add(new StringContent(formData.PartNumber), "part_number");
                }

                httpRequest.Content = form;
            }

            var response = await SendAsync(
                uri,
                HttpMethod.Post,
                queryParams,
                headers,
                AttachContent,
                basicAuthenticationParameters,
                cancellationToken
            );

            return await response.ParseStreamAsync<T>(serializerSettings);
        }

        public async Task<T> PatchAsync<T>(
            string uri,
            object body,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null,
            JsonSerializerSettings serializerSettings = null,
            CancellationToken cancellationToken = default)
        {
            void AttachContent(HttpRequestMessage httpRequest)
            {
                var serializedBody = JsonConvert.SerializeObject(body, DefaultSerializerSettings);
                httpRequest.Content = new StringContent(serializedBody, Encoding.UTF8, "application/json");
            }

            var response = await SendAsync(uri, new HttpMethod("PATCH"), queryParams, headers, AttachContent,
                basicAuthenticationParameters: null, cancellationToken);

            return await response.ParseStreamAsync<T>(serializerSettings);
        }

        public async Task DeleteAsync(
            string uri,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null,
            CancellationToken cancellationToken = default)
        {
            await SendAsync(uri, HttpMethod.Delete, queryParams, headers, null,
                basicAuthenticationParameters: null, cancellationToken);
        }

        public async Task<T> DeleteAsync<T>(
            string uri,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null,
            JsonSerializerSettings serializerSettings = null,
            CancellationToken cancellationToken = default)
        {
            var response = await SendAsync(uri, HttpMethod.Delete, queryParams, headers, null,
                basicAuthenticationParameters: null, cancellationToken);

            return await response.ParseStreamAsync<T>(serializerSettings);
        }

        private static ClientOptions MergeOptions(ClientOptions options)
        {
            return new ClientOptions
            {
                AuthToken = options.AuthToken,
                BaseUrl = options.BaseUrl ?? Constants.BaseUrl,
                NotionVersion = options.NotionVersion ?? Constants.DefaultNotionVersion,
                Timeout = options.Timeout
            };
        }

        private static async Task<Exception> BuildException(HttpResponseMessage response)
        {
            var errorBody = await response.Content.ReadAsStringAsync();

            NotionApiErrorResponse errorResponse = null;

            if (!string.IsNullOrWhiteSpace(errorBody))
            {
                try
                {
                    errorResponse = JsonConvert.DeserializeObject<NotionApiErrorResponse>(errorBody);

                    if (errorResponse.ErrorCode == NotionAPIErrorCode.RateLimited)
                    {
                        var retryAfter = response.Headers.RetryAfter.Delta;

                        return new NotionApiRateLimitException(
                            response.StatusCode,
                            errorResponse.ErrorCode,
                            errorResponse.Message,
                            retryAfter
                        );
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error when parsing the notion api response.");
                }
            }

            return new NotionApiException(response.StatusCode, errorResponse?.ErrorCode, errorResponse?.Message);
        }

        private async Task<HttpResponseMessage> SendAsync(
            string requestUri,
            HttpMethod httpMethod,
            IEnumerable<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headers = null,
            Action<HttpRequestMessage> attachContent = null,
            IBasicAuthenticationParameters basicAuthenticationParameters = null,
            CancellationToken cancellationToken = default)
        {
            ValidatePath(requestUri);

            requestUri = AddQueryString(requestUri, queryParams);

            for (var attempt = 0; ; attempt++)
            {
                // HttpRequestMessage is single-use; rebuild it for every attempt.
                using var httpRequest = new HttpRequestMessage(httpMethod, requestUri);

                httpRequest.Headers.Authorization = CreateAuthenticationHeader(basicAuthenticationParameters);
                httpRequest.Headers.Add("Notion-Version", _options.NotionVersion);
                httpRequest.Headers.UserAgent.ParseAdd(Constants.UserAgent);

                if (headers != null)
                {
                    AddHeaders(httpRequest, headers);
                }

                attachContent?.Invoke(httpRequest);

                var response = await SendWithTimeoutAsync(httpRequest, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                if (_retryPolicy == null || !_retryPolicy.ShouldRetry(response, httpMethod, attempt))
                {
                    throw await BuildException(response);
                }

                var delay = _retryPolicy.GetDelay(response, attempt);

                Log.Trace(
                    "Retry attempt {attempt} after {delay}ms (HTTP {status})",
                    attempt + 1,
                    (int)delay.TotalMilliseconds,
                    (int)response.StatusCode);

                response.Dispose();

                await Task.Delay(delay, cancellationToken);
            }
        }

        private async Task<HttpResponseMessage> SendWithTimeoutAsync(
            HttpRequestMessage httpRequest,
            CancellationToken cancellationToken)
        {
            if (_timeout == null)
            {
                return await _httpClient.SendAsync(httpRequest, cancellationToken);
            }

            using var timeoutSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            timeoutSource.CancelAfter(_timeout.Value);

            try
            {
                return await _httpClient.SendAsync(httpRequest, timeoutSource.Token);
            }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
                throw new NotionRequestTimeoutException(_timeout.Value);
            }
        }

        /// <summary>
        /// Rejects path-traversal sequences in the path part of the request URI.
        /// </summary>
        private static void ValidatePath(string requestUri)
        {
            var queryIndex = requestUri.IndexOf('?');
            var path = queryIndex >= 0 ? requestUri.Substring(0, queryIndex) : requestUri;

            if (path.Contains("..") || path.IndexOf("%2e%2e", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                throw new InvalidPathParameterException(path);
            }
        }

        private AuthenticationHeaderValue CreateAuthenticationHeader(IBasicAuthenticationParameters basicAuth)
        {
            return basicAuth != null
                ? new AuthenticationHeaderValue("Basic", HeaderHelpers.GetBasicAuthHeaderValue(basicAuth))
                : new AuthenticationHeaderValue("Bearer", _options.AuthToken);
        }

        private static void AddHeaders(HttpRequestMessage request, IDictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }

        private static string AddQueryString(string uri, IEnumerable<KeyValuePair<string, string>> queryParams)
        {
            return queryParams == null ? uri : QueryHelpers.AddQueryString(uri, queryParams);
        }
    }
}
