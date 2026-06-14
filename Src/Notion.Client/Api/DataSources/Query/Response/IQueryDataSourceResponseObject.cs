using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "object")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(Page), ObjectType.PageValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DataSource), ObjectType.DataSourceValue)]
    [JsonSubtypes.FallBackSubTypeAttribute(typeof(UnknownObject))]
    public interface IQueryDataSourceResponseObject : IObject
    {
    }
}
