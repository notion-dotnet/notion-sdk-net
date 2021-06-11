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
    }
}
