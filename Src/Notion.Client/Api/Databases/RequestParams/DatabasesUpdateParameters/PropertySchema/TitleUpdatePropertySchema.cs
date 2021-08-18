using System.Collections.Generic;

namespace Notion.Client
{
    public class TitleUpdatePropertySchema : IUpdatePropertySchema
    {
        public Dictionary<string, object> Title { get; set; }
    }
}
