using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IPagesClient
    {
        Task<Page> CreateAsync(NewPage page);

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
    }
}
