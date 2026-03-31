using Newtonsoft.Json;

namespace Notion.Client
{
    public class RichTextTextInput : RichTextBaseInput
    {
        public override RichTextType Type => RichTextType.Text;

        [JsonProperty("text")]
        public Text Text { get; set; }
    }
}
