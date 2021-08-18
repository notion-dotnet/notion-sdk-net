namespace Notion.Client
{
    public class RichTextMentionInput : RichTextBaseInput
    {
        public override RichTextType Type => RichTextType.Mention;
        public MentionInput Mention { get; set; }
    }
}
