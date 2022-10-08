using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "object")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(SimplePropertyItem), "property_item")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ListPropertyItem), "list")]
    public interface IPropertyItemObject
    {
        [JsonProperty("object")]
        string Object { get; }

        [JsonProperty("type")]
        string Type { get; }

        [JsonProperty("id")]
        string Id { get; }

        /// <summary>
        ///     Only present in paginated property values with another page of results. If present, the url the user can request to
        ///     get the next page of results.
        /// </summary>
        [JsonProperty("next_url")]
        string NextURL { get; }
    }
}
