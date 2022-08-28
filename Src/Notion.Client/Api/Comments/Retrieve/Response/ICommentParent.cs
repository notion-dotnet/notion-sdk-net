using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(PageParent), ParentType.PageId)]
    [JsonSubtypes.KnownSubType(typeof(BlockParent), ParentType.BlockId)]
    public interface ICommentParent
    {
    }
}
