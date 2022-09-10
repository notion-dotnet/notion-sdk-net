using Newtonsoft.Json;

namespace Notion.Client
{
    public class RichTextPropertyItem : SimplePropertyItem
    {
        public override string Type => "rich_text";

        [JsonProperty("rich_text")]
        public RichTextBase RichText { get; set; }
    }
}
