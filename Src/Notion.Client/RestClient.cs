using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Notion.Client.http;

namespace Notion.Client
{
    public interface IRestClient
    {
        Task<T> GetAsync<T>(string uri, Dictionary<string, string> queryParams = null);
        Task<T> PostAsync<T>(string uri, object body);
    }

    public class RestClient : IRestClient
    {
        private HttpClient _httpClient;
        private readonly ClientOptions _options;
        private readonly List<JsonConverter> jsonConverters = new List<JsonConverter>();

        private readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings
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

        public async Task<T> GetAsync<T>(string uri, Dictionary<string, string> queryParams = null)
        {
            EnsureHttpClient();

            uri = queryParams == null ? uri : QueryHelpers.AddQueryString(uri, queryParams);

            using (var stream = await _httpClient.GetStreamAsync(uri))
            {
                return SerializerHelper.Deserialize<T>(stream, jsonConverters);
            }
        }

        public async Task<T> PostAsync<T>(string uri, object body)
        {
            EnsureHttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(body, serializerSettings), Encoding.UTF8, "application/json");

            using (var response = await _httpClient.PostAsync(uri, content))
            {
                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStreamAsync();

                return SerializerHelper.Deserialize<T>(stream, jsonConverters);
            }
        }

        private HttpClient EnsureHttpClient()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
                _httpClient.BaseAddress = new Uri(_options.BaseUrl);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _options.AuthToken);
                _httpClient.DefaultRequestHeaders.Add("Notion-Version", _options.NotionVersion);
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
