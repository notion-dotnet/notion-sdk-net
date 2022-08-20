namespace Notion.Client
{
    public class PartialUser : IObject
    {
        public string Id { get; set; }

        public ObjectType Object => ObjectType.User;
    }
}
