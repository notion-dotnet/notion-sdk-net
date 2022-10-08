using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DatabaseParent), ParentType.DatabaseId)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PageParent), ParentType.PageId)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(WorkspaceParent), ParentType.Workspace)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(BlockParent), ParentType.BlockId)]
    public interface IPageParent : IParent
    {
    }
}
