using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class RichTextPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.RichText;

        [JsonProperty("rich_text")]
        public List<RichTextBase> RichText { get; set; }
    }

}
