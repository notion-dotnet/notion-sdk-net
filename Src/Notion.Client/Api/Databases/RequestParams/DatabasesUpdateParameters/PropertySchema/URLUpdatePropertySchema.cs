using System.Collections.Generic;

namespace Notion.Client
{
    public class URLUpdatePropertySchema : IUpdatePropertySchema
    {
        public Dictionary<string, object> Url { get; set; }
    }
}
