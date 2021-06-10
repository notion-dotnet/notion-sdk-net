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

        public async Task<RetrievedPage> RetrieveAsync(string pageId)
        {
            var url = PagesApiUrls.Retrieve(pageId);
            return await _client.GetAsync<RetrievedPage>(url);
        }

        public async Task<RetrievedPage> UpdatePropertiesAsync(
            string pageId,
            IDictionary<string, PropertyValue> updatedProperties)
        {
            var url = PagesApiUrls.UpdateProperties(pageId);
            var body = new UpdatePropertiesParameters { Properties = updatedProperties };

            return await _client.PatchAsync<RetrievedPage>(url, body);
        }

        private class UpdatePropertiesParameters
        {
            public IDictionary<string, PropertyValue> Properties { get; set; }
        }
    }
}
