using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "object")]
    [JsonSubtypes.KnownSubType(typeof(Page), ObjectType.Page)]
    [JsonSubtypes.KnownSubType(typeof(Database), ObjectType.Database)]
    [JsonSubtypes.KnownSubType(typeof(IBlock), ObjectType.Block)]
    [JsonSubtypes.KnownSubType(typeof(User), ObjectType.User)]
    public interface IObject
    {
        [JsonProperty("id")]
        string Id { get; set; }

        [JsonProperty("object")]
        [JsonConverter(typeof(StringEnumConverter))]
        ObjectType Object { get; }
    }
}
