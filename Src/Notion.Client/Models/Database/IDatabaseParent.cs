using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PageParent), ParentType.PageId)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(WorkspaceParent), ParentType.Workspace)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(BlockParent), ParentType.BlockId)]
    public interface IDatabaseParent : IParent
    {
    }
}
