using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IPagesClient
    {
        Task<RetrievedPage> CreateAsync(CreatedPage page);
        Task<RetrievedPage> UpdatePagePropertiesAsync(
            string pageId,
            IDictionary<string, PropertyValue> updatedProperties
        );

    }
}
