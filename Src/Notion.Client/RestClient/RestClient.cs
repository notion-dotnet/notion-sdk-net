using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public RestClient(ClientOptions options)
        {
            _options = MergeOptions(options);
            _retryPolicy = options.RetryPolicy;
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
                NotionVersion = options.NotionVersion ?? Constants.DefaultNotionVersion
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
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error when parsing the notion api response.");
                }
            }

            var responseHeaders = GetResponseHeaders(response);
            responseHeaders.TryGetValue("cf-ray", out var rayId);
            responseHeaders.TryGetValue("x-notion-request-id", out var requestIdHeader);

            // A Notion error always has a code and/or a message; anything else (an empty body, an HTML
            // error page from the edge proxy, ...) is an unknown response.
            var isNotionError = errorResponse != null
                                && (errorResponse.Message != null
                                    || !string.IsNullOrEmpty(errorResponse.ErrorCode.ToString()));

            NotionApiException exception;

            if (!isNotionError)
            {
                exception = new NotionUnknownResponseException(
                    response.StatusCode,
                    BuildUnknownResponseMessage(response.StatusCode, rayId));
            }
            else if (errorResponse.ErrorCode == NotionAPIErrorCode.RateLimited)
            {
                exception = new NotionApiRateLimitException(
                    response.StatusCode,
                    errorResponse.ErrorCode,
                    errorResponse.Message,
                    GetRetryAfter(response)
                );
            }
            else
            {
                exception = new NotionApiException(response.StatusCode, errorResponse.ErrorCode, errorResponse.Message);
            }

            exception.RequestId = errorResponse?.RequestId ?? requestIdHeader;
            exception.RayId = rayId;
            exception.AdditionalData = errorResponse?.AdditionalData;
            exception.ResponseBody = errorBody;
            exception.ResponseHeaders = responseHeaders;

            return exception;
        }

        private static string BuildUnknownResponseMessage(HttpStatusCode statusCode, string rayId)
        {
            var message = $"Request to Notion API failed with status: {(int)statusCode}.";

            if (rayId != null)
            {
                message += $" The response came from Notion's edge proxy (Cloudflare Ray ID: {rayId}).";

                if (statusCode == HttpStatusCode.Forbidden)
                {
                    message += " A 403 from the edge proxy usually means the request was blocked before reaching the API.";
                }
            }

            return message;
        }

        private static Dictionary<string, string> GetResponseHeaders(HttpResponseMessage response)
        {
            var headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var header in response.Headers.Concat(response.Content.Headers))
            {
                headers[header.Key] = string.Join(", ", header.Value);
            }

            return headers;
        }

        private static TimeSpan? GetRetryAfter(HttpResponseMessage response)
        {
            var retryAfter = response.Headers.RetryAfter;

            if (retryAfter?.Delta is { } delta)
            {
                return delta;
            }

            return retryAfter?.Date is { } date ? date - DateTimeOffset.UtcNow : (TimeSpan?)null;
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
            requestUri = AddQueryString(requestUri, queryParams);

            for (var attempt = 0; ; attempt++)
            {
                // HttpRequestMessage is single-use; rebuild it for every attempt.
                using var httpRequest = new HttpRequestMessage(httpMethod, requestUri);

                httpRequest.Headers.Authorization = CreateAuthenticationHeader(basicAuthenticationParameters);
                httpRequest.Headers.Add("Notion-Version", _options.NotionVersion);

                if (headers != null)
                {
                    AddHeaders(httpRequest, headers);
                }

                attachContent?.Invoke(httpRequest);

                var response = await _httpClient.SendAsync(httpRequest, cancellationToken);

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
