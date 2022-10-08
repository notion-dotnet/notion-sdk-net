using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        /// <summary>
        ///     Creates a new page in the specified database or as a child of an existing page.
        ///     If the parent is a database, the
        ///     <see href="https://developers.notion.com/reference-link/page#property-value-object">property values</see> of the
        ///     new page in the properties parameter must conform to the parent
        ///     <see href="https://developers.notion.com/reference-link/database">database</see>'s property schema.
        ///     If the parent is a page, the only valid property is <strong>title</strong>.
        /// </summary>
        /// <param name="pagesCreateParameters">Create page parameters</param>
        /// <returns>Created page.</returns>
        public async Task<Page> CreateAsync(PagesCreateParameters pagesCreateParameters)
        {
            if (pagesCreateParameters is null)
            {
                throw new ArgumentNullException(nameof(pagesCreateParameters));
            }

            var bodyParameters = (IPagesCreateBodyParameters)pagesCreateParameters;

            if (bodyParameters.Parent == null)
            {
                throw new ArgumentNullException(nameof(bodyParameters.Parent), "Parent is required!");
            }

            if (bodyParameters.Properties == null)
            {
                throw new ArgumentNullException(nameof(bodyParameters.Properties), "Properties are required!");
            }

            return await _client.PostAsync<Page>(PagesApiUrls.Create(), bodyParameters);
        }

        public async Task<Page> RetrieveAsync(string pageId)
        {
            var url = PagesApiUrls.Retrieve(pageId);

            return await _client.GetAsync<Page>(url);
        }

        public async Task<IPropertyItemObject> RetrievePagePropertyItemAsync(
            RetrievePropertyItemParameters retrievePropertyItemParameters)
        {
            var pathParameters = (IRetrievePropertyItemPathParameters)retrievePropertyItemParameters;
            var queryParameters = (IRetrievePropertyQueryParameters)retrievePropertyItemParameters;

            var url = PagesApiUrls.RetrievePropertyItem(pathParameters.PageId, pathParameters.PropertyId);

            var queryParams = new Dictionary<string, string>
            {
                { "start_cursor", queryParameters?.StartCursor },
                { "page_size", queryParameters?.PageSize?.ToString() }
            };

            return await _client.GetAsync<IPropertyItemObject>(url, queryParams);
        }

        public async Task<Page> UpdateAsync(string pageId, PagesUpdateParameters pagesUpdateParameters)
        {
            var url = PagesApiUrls.Update(pageId);
            var body = (IPagesUpdateBodyParameters)pagesUpdateParameters;

            return await _client.PatchAsync<Page>(url, body);
        }

        [Obsolete("This method is obsolete. Use UpdateAsync instead. This API will be removed in future release")]
        public async Task<Page> UpdatePropertiesAsync(
            string pageId,
            IDictionary<string, PropertyValue> updatedProperties)
        {
            var url = PagesApiUrls.UpdateProperties(pageId);

            var body = new UpdatePropertiesParameters { Properties = updatedProperties };

            return await _client.PatchAsync<Page>(url, body);
        }

        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
        private class UpdatePropertiesParameters
        {
            public IDictionary<string, PropertyValue> Properties { get; set; }
        }
    }
}
