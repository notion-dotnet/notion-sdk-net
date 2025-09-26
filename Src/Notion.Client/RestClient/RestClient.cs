using System;
using System.Collections.Generic;
using System.IO;
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

        private HttpClient _httpClient;

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
                httpRequest.Content = new StringContent(JsonConvert.SerializeObject(body, DefaultSerializerSettings),
                    Encoding.UTF8, "application/json");
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

        public async Task<UploadResponse> Upload(string filePath, JsonSerializerSettings serializerSettings = null)
        {
            var fileStream = File.OpenRead(filePath);
            return await Upload(fileStream, Path.GetFileName(filePath), serializerSettings);
        }
        
        public async Task<UploadResponse> Upload(Stream stream, string filename, JsonSerializerSettings serializerSettings = null)
        {
            var response = await this.PostAsync<UploadResponse>("https://api.notion.com/v1/file_uploads",
                new UploadRequest {Mode = "single_part"});

            using (var formData = new MultipartFormDataContent())
            {
                var fileContent = new StreamContent(stream);

                var mimeMapping = new Dictionary<string, string>
                {
                    {".jpg", "image/jpeg"},
                    {".jpeg", "image/jpeg"},
                    {".png", "image/png"},
                    {".tif", "image/tiff"},
                    {".tiff", "image/tiff"},
                    {".gif", "image/gif"},
                    {".svg", "image/svg+xml"}
                };
                
                if (mimeMapping.TryGetValue(Path.GetExtension(filename).ToLower(), out var mapping))
                {
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(mapping);
                }
                formData.Add(fileContent, "file", filename);

                var uploadResponse = await this.SendAsync(response.UploadUrl, HttpMethod.Post,
                    attachContent: message =>
                    {
                        message.Content = formData;
                    });
                return await uploadResponse.ParseStreamAsync<UploadResponse>(serializerSettings);
            }
        }
        
        public class UploadRequest
        {
            public string Mode { get; set; }
        }

        public class UploadResponse
        {
            public Guid Id { get; set; }
            public string Object { get; set; }
            [JsonProperty("created_time")]
            public DateTime CreatedTime { get; set; }
            [JsonProperty("last_edited_time")]
            public DateTime LastEditedTime { get; set; }
            [JsonProperty("expiry_time")]
            public DateTime ExpiryTime { get; set; }
            [JsonProperty("upload_url")]
            public string UploadUrl { get; set; }
            public bool Archived { get; set; }
            public string Status { get; set; }
            public string Filename { get; set; }
            [JsonProperty("content_type")]
            public string ContentType { get; set; }
            [JsonProperty("request_id")]
            public Guid RequestId { get; set; }
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
            EnsureHttpClient();

            requestUri = AddQueryString(requestUri, queryParams);

            using var httpRequest = new HttpRequestMessage(httpMethod, requestUri);

            httpRequest.Headers.Authorization = CreateAuthenticationHeader(basicAuthenticationParameters);
            httpRequest.Headers.Add("Notion-Version", _options.NotionVersion);

            if (headers != null)
            {
                AddHeaders(httpRequest, headers);
            }

            attachContent?.Invoke(httpRequest);

            var response = await _httpClient.SendAsync(httpRequest, cancellationToken);

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

        private void EnsureHttpClient()
        {
            if (_httpClient != null)
            {
                return;
            }

            var pipeline = new LoggingHandler { InnerHandler = new HttpClientHandler() };

            _httpClient = new HttpClient(pipeline);
            _httpClient.BaseAddress = new Uri(_options.BaseUrl);
        }

        private static string AddQueryString(string uri, IEnumerable<KeyValuePair<string, string>> queryParams)
        {
            return queryParams == null ? uri : QueryHelpers.AddQueryString(uri, queryParams);
        }
    }
}
