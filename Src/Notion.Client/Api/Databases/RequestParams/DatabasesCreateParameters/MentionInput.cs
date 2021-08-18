namespace Notion.Client
{
    public class MentionInput
    {
        public string Type { get; set; }
        public Person User { get; set; }
        public ObjectId Page { get; set; }
        public ObjectId Database { get; set; }
        public DatePropertyValue Date { get; set; }
    }
}
