using Newtonsoft.Json;

namespace Notion.Client
{
    public class TitlePropertyItem : SimplePropertyItem
    {
        public override string Type => "title";

        [JsonProperty("title")]
        public RichTextBase Title { get; set; }
    }
}
