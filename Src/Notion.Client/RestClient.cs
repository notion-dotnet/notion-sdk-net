using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Notion.Client.http;

namespace Notion.Client
{
    public interface IRestClient
    {
        Task<T> GetAsync<T>(string uri, Dictionary<string, string> queryParams = null);
    }

    public class RestClient : IRestClient
    {
        private HttpClient _httpClient;
        private readonly ClientOptions _options;

        // Todo: Is there a better way?
        private readonly List<JsonConverter> jsonConverters = new List<JsonConverter>{
            new PropertyConverter()
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

        private HttpClient EnsureHttpClient()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
                _httpClient.BaseAddress = new Uri(_options.BaseUrl);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _options.AuthToken);
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
