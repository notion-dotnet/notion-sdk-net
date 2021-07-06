using System.Threading.Tasks;
using static Notion.Client.ApiEndpoints;

namespace Notion.Client
{
    public class SearchClient : ISearchClient
    {
        private readonly IRestClient client;

        public SearchClient(IRestClient client)
        {
            this.client = client;
        }

        public async Task<PaginatedList<IObject>> SearchAsync(SearchParameters parameters)
        {
            var url = SearchApiUrls.Search();

            var body = (ISearchBodyParameters)parameters;

            return await client.PostAsync<PaginatedList<IObject>>(url, body);
        }
    }
}
