using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(DatabaseParent), ParentType.DatabaseId)]
    [JsonSubtypes.KnownSubType(typeof(PageParent), ParentType.PageId)]
    [JsonSubtypes.KnownSubType(typeof(WorkspaceParent), ParentType.Workspace)]
    [JsonSubtypes.KnownSubType(typeof(BlockParent), ParentType.BlockId)]
    public interface IBlockParent : IParent
    {
    }
}
