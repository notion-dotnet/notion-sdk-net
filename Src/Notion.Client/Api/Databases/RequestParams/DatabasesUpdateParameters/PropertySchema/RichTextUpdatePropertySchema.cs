using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class RichTextUpdatePropertySchema : IUpdatePropertySchema
    {
        [JsonProperty("rich_text")]
        public Dictionary<string, object> RichText { get; set; }
    }
}
