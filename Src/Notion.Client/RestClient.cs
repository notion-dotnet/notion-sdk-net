using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IRestClient
    {
        Task<T> GetAsync<T>(string uri);
    }

    public class RestClient : IRestClient
    {
        private readonly string _authToken;
        private HttpClient _httpClient;

        public RestClient(string authToken)
        {
            _authToken = authToken;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            EnsureHttpClient();

            using (var stream = await _httpClient.GetStreamAsync(uri))
            {
                return SerializerHelper.Deserialize<T>(stream);
            }
        }

        private HttpClient EnsureHttpClient()
        {
            if(_httpClient == null)
            {
                _httpClient = new HttpClient();
                _httpClient.BaseAddress = Constants.BASE_URL;
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
            }

            return _httpClient;
        }
    }
}
