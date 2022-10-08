using System.Threading.Tasks;
using static Notion.Client.ApiEndpoints;

namespace Notion.Client
{
    public class SearchClient : ISearchClient
    {
        private readonly IRestClient _client;

        public SearchClient(IRestClient client)
        {
            _client = client;
        }

        public async Task<PaginatedList<IObject>> SearchAsync(SearchParameters parameters)
        {
            var url = SearchApiUrls.Search();

            var body = (ISearchBodyParameters)parameters;

            return await _client.PostAsync<PaginatedList<IObject>>(url, body);
        }
    }
}
