namespace Notion.Client
{
    public class RichTextTextInput : RichTextBaseInput
    {
        public override RichTextType Type => RichTextType.Text;
        public Text Text { get; set; }
    }
}
