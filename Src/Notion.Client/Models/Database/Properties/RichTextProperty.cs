using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class RichTextProperty : Property
    {
        public override PropertyType Type => PropertyType.RichText;

        [JsonProperty("rich_text")]
        public Dictionary<string, object> RichText { get; set; }
    }
}
