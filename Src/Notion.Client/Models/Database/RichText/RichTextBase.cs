using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RichTextText), RichTextType.Text)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RichTextEquation), RichTextType.Equation)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RichTextMention), RichTextType.Mention)]
    public class RichTextBase
    {
        [JsonProperty("plain_text")]
        public string PlainText { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("annotations")]
        public Annotations Annotations { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual RichTextType Type { get; set; }
    }

    public class Annotations
    {
        [JsonProperty("bold")]
        public bool IsBold { get; set; }

        [JsonProperty("italic")]
        public bool IsItalic { get; set; }

        [JsonProperty("strikethrough")]
        public bool IsStrikeThrough { get; set; }

        [JsonProperty("underline")]
        public bool IsUnderline { get; set; }

        [JsonProperty("code")]
        public bool IsCode { get; set; }

        [JsonProperty("color")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Color? Color { get; set; }
    }
}
