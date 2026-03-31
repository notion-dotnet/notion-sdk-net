using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "object")]
    [JsonSubtypes.KnownSubType(typeof(Page), ObjectType.Page)]
    [JsonSubtypes.KnownSubType(typeof(DataSource), ObjectType.DataSource)]
    public interface ISearchResponseObject : IObject
    {
    }
}
