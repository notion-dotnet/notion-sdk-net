using System.Collections.Generic;
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

        public async Task<RetrievedPage> UpdatePagePropertiesAsync(
            string pageId,
            IDictionary<string, PropertyValue> updatedProperties)
        {
            var url = PagesApiUrls.UpdatePageProperties(pageId);
            var body = new PageUpdatePropertiesParameters { Properties = updatedProperties };

            return await _client.PatchAsync<RetrievedPage>(url, body);
        }

        private class PageUpdatePropertiesParameters
        {
            public IDictionary<string, PropertyValue> Properties { get; set; }
        }
    }
}
