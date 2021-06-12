using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "object")]
    [JsonSubtypes.KnownSubType(typeof(Page), ObjectType.Page)]
    [JsonSubtypes.KnownSubType(typeof(Database), ObjectType.Database)]
    [JsonSubtypes.KnownSubType(typeof(Block), ObjectType.Block)]
    [JsonSubtypes.KnownSubType(typeof(User), ObjectType.User)]
    public interface IObject
    {
        string Id { get; set; }
        ObjectType Object { get; }
    }
}
