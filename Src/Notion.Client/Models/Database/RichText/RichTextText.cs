namespace Notion.Client
{
    public class RichTextText : RichTextBase
    {
        public override RichTextType Type => RichTextType.Text;
        public Text Text { get; set; }
    }

    public class Text
    {
        public string Content { get; set; }
        public Link Link { get; set; }
    }

    public class Link
    {
        public string Type => "url";
        public string Url { get; set; }
    }
}
