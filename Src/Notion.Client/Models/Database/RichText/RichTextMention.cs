using Newtonsoft.Json;

namespace Notion.Client
{
    public class RichTextMention : RichTextBase
    {
        public override RichTextType Type => RichTextType.Mention;

        [JsonProperty("mention")]
        public Mention Mention { get; set; }
    }

    public class Mention
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("page")]
        public ObjectId Page { get; set; }

        [JsonProperty("database")]
        public ObjectId Database { get; set; }

        [JsonProperty("date")]
        public Date Date { get; set; }

        [JsonProperty("link_preview")]
        public LinkPreviewMention LinkPreview { get; set; }

        [JsonProperty("link_mention")]
        public LinkMention LinkMention { get; set; }

        [JsonProperty("template_mention")]
        public TemplateMention TemplateMention { get; set; }

        [JsonProperty("custom_emoji")]
        public CustomEmoji CustomEmoji { get; set; }
    }

    public class ObjectId
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
