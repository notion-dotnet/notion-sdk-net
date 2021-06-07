using System.Threading.Tasks;
using static Notion.Client.ApiEndpoints;

namespace Notion.Client
{
    public class PagesClient : IPagesClient
    {
        private readonly IRestClient _client;

        public PagesClient(IRestClient client)
        {
            _client = client;
        }

        public async Task<RetrievedPage> CreateAsync(CreatedPage page)
        {
            return await _client.PostAsync<RetrievedPage>(PagesApiUrls.Create(), page);
        }
    }

}
