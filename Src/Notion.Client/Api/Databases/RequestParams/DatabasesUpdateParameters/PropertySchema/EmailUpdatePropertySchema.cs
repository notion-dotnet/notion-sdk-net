using System.Collections.Generic;

namespace Notion.Client
{
    public class EmailUpdatePropertySchema : IUpdatePropertySchema
    {
        public Dictionary<string, object> Email { get; set; }
    }
}
