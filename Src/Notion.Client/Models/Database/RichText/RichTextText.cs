using Newtonsoft.Json;

namespace Notion.Client
{
    public class RichTextText : RichTextBase
    {
        public override RichTextType Type => RichTextType.Text;

        [JsonProperty("text")]
        public Text Text { get; set; }
    }

    public class Text
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("link")]
        public Link Link { get; set; }
    }

    public class Link
    {
        [JsonProperty("type")]
        public string Type => "url";

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
