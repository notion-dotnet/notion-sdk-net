using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Notion.Client.Extensions;
using Notion.Client.http;

namespace Notion.Client
{
    public interface IRestClient
    {
        Task<T> GetAsync<T>(
            string uri,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null,
            JsonSerializerSettings serializerSettings = null,
            CancellationToken cancellationToken = default);

        Task<T> PostAsync<T>(
            string uri,
            object body,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null,
            JsonSerializerSettings serializerSettings = null,
            CancellationToken cancellationToken = default);
    }

    public class RestClient : IRestClient
    {
        private HttpClient _httpClient;
        private readonly ClientOptions _options;
        private readonly List<JsonConverter> jsonConverters = new List<JsonConverter>();

        private readonly JsonSerializerSettings defaultSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public RestClient(ClientOptions options)
        {
            _options = MergeOptions(options);
        }

        private static ClientOptions MergeOptions(ClientOptions options)
        {
            return new ClientOptions
            {
                AuthToken = options.AuthToken,
                BaseUrl = options.BaseUrl ?? Constants.BASE_URL,
                NotionVersion = options.NotionVersion ?? Constants.DEFAULT_NOTION_VERSION
            };
        }

        public async Task<T> GetAsync<T>(
            string uri,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null,
            JsonSerializerSettings serializerSettings = null,
            CancellationToken cancellationToken = default)
        {
            EnsureHttpClient();

            string requestUri = queryParams == null ? uri : QueryHelpers.AddQueryString(uri, queryParams);

            var response = await SendAsync(requestUri, HttpMethod.Get, headers, cancellationToken: cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return await response.ParseStreamAsync<T>(serializerSettings);
            }

            var message = !string.IsNullOrWhiteSpace(response.ReasonPhrase)
                    ? response.ReasonPhrase
                    : await response.Content.ReadAsStringAsync();

            throw new NotionApiException(response.StatusCode, message);
        }

        private async Task<HttpResponseMessage> SendAsync(
            string requestUri,
            HttpMethod httpMethod,
            IDictionary<string, string> headers = null,
            Action<HttpRequestMessage> attachContent = null,
            CancellationToken cancellationToken = default)
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(httpMethod, requestUri);
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _options.AuthToken);
            httpRequest.Headers.Add("Notion-Version", _options.NotionVersion);

            if (headers != null)
            {
                AddHeaders(httpRequest, headers);
            }

            attachContent?.Invoke(httpRequest);

            return await _httpClient.SendAsync(httpRequest, cancellationToken);
        }

        private static void AddHeaders(HttpRequestMessage request, IDictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }

        public async Task<T> PostAsync<T>(
            string uri,
            object body,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null,
            JsonSerializerSettings serializerSettings = null,
            CancellationToken cancellationToken = default)
        {
            EnsureHttpClient();

            void AttachContent(HttpRequestMessage httpRequest)
            {
                httpRequest.Content = new StringContent(JsonConvert.SerializeObject(body, defaultSerializerSettings), Encoding.UTF8, "application/json");
            }

            string requestUri = queryParams == null ? uri : QueryHelpers.AddQueryString(uri, queryParams);

            var response = await SendAsync(requestUri, HttpMethod.Post, headers, AttachContent, cancellationToken: cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return await response.ParseStreamAsync<T>(serializerSettings);
            }

            var message = !string.IsNullOrWhiteSpace(response.ReasonPhrase)
                    ? response.ReasonPhrase
                    : await response.Content.ReadAsStringAsync();

            throw new NotionApiException(response.StatusCode, message);
        }

        private HttpClient EnsureHttpClient()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
                _httpClient.BaseAddress = new Uri(_options.BaseUrl);
            }

            return _httpClient;
        }
    }

    public class ClientOptions
    {
        public string BaseUrl { get; set; }
        public string NotionVersion { get; set; }
        public string AuthToken { get; set; }
    }
}
