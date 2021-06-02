namespace Notion.Client
{
    public class RichTextMention : RichTextBase
    {
        public override RichTextType Type => RichTextType.Mention;
        public Mention Mention { get; set; }
    }

    public class Mention
    {
        public string Type { get; set; }
        public User User { get; set; }
        public ObjectId Page { get; set; }
        public ObjectId Database { get; set; }
        public DatePropertyValue Date { get; set; }
    }

    public class ObjectId
    {
        public string Id { get; set; }
    }
}
