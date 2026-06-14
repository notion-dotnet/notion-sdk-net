using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "object")]
    [JsonSubtypes.KnownSubType(typeof(Page), ObjectType.PageValue)]
    [JsonSubtypes.KnownSubType(typeof(DataSource), ObjectType.DataSourceValue)]
    [JsonSubtypes.FallBackSubTypeAttribute(typeof(UnknownObject))]
    public interface ISearchResponseObject : IObject
    {
    }
}
