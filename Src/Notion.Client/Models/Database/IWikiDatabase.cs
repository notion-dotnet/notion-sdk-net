using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "object")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(Page), ObjectType.Page)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(Database), ObjectType.Database)]
    public interface IWikiDatabase : IObject
    {
    }
}
