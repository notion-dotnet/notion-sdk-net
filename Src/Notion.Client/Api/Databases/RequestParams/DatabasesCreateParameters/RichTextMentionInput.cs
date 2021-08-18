namespace Notion.Client
{
    public class RichTextMentionInput : RichTextBaseInput
    {
        public override RichTextType Type => RichTextType.Mention;
        public MentionInput Mention { get; set; }
    }

    public class MentionInput
    {
        public string Type { get; set; }
        public Person User { get; set; }
        public ObjectId Page { get; set; }
        public ObjectId Database { get; set; }
        public DatePropertyValue Date { get; set; }
    }
}
