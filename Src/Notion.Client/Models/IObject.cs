using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "object")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(Page), ObjectType.Page)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(Database), ObjectType.Database)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(IBlock), ObjectType.Block)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(User), ObjectType.User)]
    public interface IObject
    {
        [JsonProperty("id")]
        string Id { get; set; }

        [JsonProperty("object")]
        [JsonConverter(typeof(StringEnumConverter))]
        ObjectType Object { get; }
    }
}
