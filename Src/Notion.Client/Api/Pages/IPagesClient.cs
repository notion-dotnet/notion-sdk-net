using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IPagesClient
    {
        /// <summary>
        /// Creates a new page in the specified database or as a child of an existing page.
        /// 
        /// If the parent is a database, the <see href="https://developers.notion.com/reference-link/page#property-value-object">property values</see> of the new page in the properties parameter must conform to the parent <see href="https://developers.notion.com/reference-link/database">database</see>'s property schema.
        /// 
        /// If the parent is a page, the only valid property is <strong>title</strong>.
        /// </summary>
        /// <param name="pagesCreateParameters">Create page parameters</param>
        /// <returns>Created page.</returns>
        Task<Page> CreateAsync(PagesCreateParameters pagesCreateParameters);

        Task<Page> RetrieveAsync(string pageId);

        Task<Page> UpdatePropertiesAsync(
            string pageId,
            IDictionary<string, PropertyValue> updatedProperties
        );

        /// <summary>
        /// Updates page property values for the specified page. 
        /// Properties that are not set via the properties parameter will remain unchanged.
        /// </summary>
        /// <param name="pageId"></param>
        /// <param name="pagesUpdateParameters"></param>
        /// <returns>Updated page.</returns>
        Task<Page> UpdateAsync(string pageId, PagesUpdateParameters pagesUpdateParameters);

        /// <summary>
        /// Retrieves a property_item object for a given pageId and propertyId. Depending on the property type, the object returned will either be a value or a paginated list of property item values.
        /// </summary>
        /// <param name="retrievePropertyItemParameters">sdf sd</param>
        /// <returns><see cref="IPropertyItemObject"/></returns>
        Task<IPropertyItemObject> RetrievePagePropertyItem(RetrievePropertyItemParameters retrievePropertyItemParameters);
    }
}
