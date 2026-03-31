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

        protected readonly JsonSerializerSettings DefaultSerializerSettings = new()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() }
        };

        public RestClient(ClientOptions options)
        {
            _options = MergeOptions(options);
        }

        public async Task<T> GetAsync<T>(
            string uri,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null,
            JsonSerializerSettings serializerSettings = null,
            CancellationToken cancellationToken = default)
        {
            using var response = await SendAsync(uri, HttpMethod.Get, queryParams, headers,
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
            using var client = GetHttpClient();

            requestUri = AddQueryString(requestUri, queryParams);

            using var httpRequest = new HttpRequestMessage(httpMethod, requestUri);

            httpRequest.Headers.Authorization = CreateAuthenticationHeader(basicAuthenticationParameters);
            httpRequest.Headers.Add("Notion-Version", _options.NotionVersion);

            if (headers != null)
            {
                AddHeaders(httpRequest, headers);
            }

            attachContent?.Invoke(httpRequest);

            var response = await client.SendAsync(httpRequest, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw await BuildException(response);
            }

            return response;
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

        private HttpClient GetHttpClient()
        {
            var pipeline = new LoggingHandler { InnerHandler = new HttpClientHandler() };

            var httpClient = new HttpClient(pipeline);
            httpClient.BaseAddress = new Uri(_options.BaseUrl);
            return httpClient;
        }

        private static string AddQueryString(string uri, IEnumerable<KeyValuePair<string, string>> queryParams)
        {
            return queryParams == null ? uri : QueryHelpers.AddQueryString(uri, queryParams);
        }
    }
}
