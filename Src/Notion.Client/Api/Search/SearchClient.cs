using System.Threading;
using System.Threading.Tasks;
using static Notion.Client.ApiEndpoints;

namespace Notion.Client
{
    public sealed class SearchClient : ISearchClient
    {
        private readonly IRestClient _client;

        public SearchClient(IRestClient client)
        {
            _client = client;
        }

        public async Task<SearchResponse> SearchAsync(
            SearchRequest request,
            CancellationToken cancellationToken = default)
        {
            var url = SearchApiUrls.Search();

            var body = (ISearchBodyParameters)request;

            return await _client.PostAsync<SearchResponse>(url, body, cancellationToken: cancellationToken);
        }
    }
}
