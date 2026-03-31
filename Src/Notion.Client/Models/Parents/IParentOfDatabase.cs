using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DatabaseParent), "database_id")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PageParent), "page_id")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(WorkspaceParent), "workspace")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(BlockParent), "block_id")]
    public interface IParentOfDatabase
    {
        [JsonProperty("type")]
        string Type { get; set; }
    }
}
