using Newtonsoft.Json;

namespace Notion.Client
{
    public class RichTextMentionInput : RichTextBaseInput
    {
        public override RichTextType Type => RichTextType.Mention;

        [JsonProperty("mention")]
        public MentionInput Mention { get; set; }
    }
}
