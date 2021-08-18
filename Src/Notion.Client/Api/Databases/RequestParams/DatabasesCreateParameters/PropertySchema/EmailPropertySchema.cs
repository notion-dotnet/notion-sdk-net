using System.Collections.Generic;

namespace Notion.Client
{
    public class EmailPropertySchema : IPropertySchema
    {
        public Dictionary<string, object> Email { get; set; }
    }
}
