using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "object")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(Page), ObjectType.Page)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DataSource), ObjectType.DataSource)]
    public interface IQueryDataSourceResponseObject : IObject
    {
    }
}
