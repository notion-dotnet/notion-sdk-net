using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IPagesClient
    {
        Task<Page> CreateAsync(NewPage page);
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
