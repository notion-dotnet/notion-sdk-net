using System.Collections.Generic;

namespace Notion.Client
{
    public class PagesUpdateParameters : IPagesUpdateBodyParameters
    {
        public bool Archived { get; set; }
        public IDictionary<string, PropertyValue> Properties { get; set; }
    }
}
