using System.Diagnostics.CodeAnalysis;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class PartialUser : IObject
    {
        public string Id { get; set; }

        public ObjectType Object => ObjectType.User;
    }
}
