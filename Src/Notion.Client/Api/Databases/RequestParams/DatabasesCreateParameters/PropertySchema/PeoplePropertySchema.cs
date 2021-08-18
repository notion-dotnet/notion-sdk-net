using System.Collections.Generic;

namespace Notion.Client
{
    public class PeoplePropertySchema : IPropertySchema
    {
        public Dictionary<string, object> People { get; set; }
    }
}
