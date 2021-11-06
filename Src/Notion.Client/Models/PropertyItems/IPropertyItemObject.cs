using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "object")]
    [JsonSubtypes.KnownSubType(typeof(SimplePropertyItem), "property_item")]
    [JsonSubtypes.KnownSubType(typeof(ListPropertyItem), "list")]
    public interface IPropertyItemObject
    {
        [JsonProperty("object")]
        string Object { get; }

        [JsonProperty("type")]
        string Type { get; }
    }
}
