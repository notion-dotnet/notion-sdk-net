using System.Collections.Generic;

namespace Notion.Client
{
    public class PeopleUpdatePropertySchema : IUpdatePropertySchema
    {
        public Dictionary<string, object> People { get; set; }
    }
}
