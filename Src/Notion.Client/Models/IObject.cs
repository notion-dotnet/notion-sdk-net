using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "object")]
    [JsonSubtypes.KnownSubType(typeof(Page), ObjectType.PageValue)]
    [JsonSubtypes.KnownSubType(typeof(Database), ObjectType.DatabaseValue)]
    [JsonSubtypes.KnownSubType(typeof(IBlock), ObjectType.BlockValue)]
    [JsonSubtypes.KnownSubType(typeof(User), ObjectType.UserValue)]
    [JsonSubtypes.KnownSubType(typeof(PageMarkdownResponse), ObjectType.PageMarkdownValue)]
    [JsonSubtypes.FallBackSubTypeAttribute(typeof(NotionObject))]
    public interface IObject
    {
        [JsonProperty("id")]
        string Id { get; set; }

        [JsonProperty("object")]
        ObjectType Object { get; }
    }
}
