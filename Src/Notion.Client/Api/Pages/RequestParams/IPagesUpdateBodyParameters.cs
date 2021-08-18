using System.Collections.Generic;

namespace Notion.Client
{
    public interface IPagesUpdateBodyParameters
    {
        bool Archived { get; set; }
        IDictionary<string, PropertyValue> Properties { get; set; }
    }
}
