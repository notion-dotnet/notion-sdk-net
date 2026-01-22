using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ExternalPageCover), "external")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FilePageCover), "file")]
    [JsonSubtypes.FallBackSubTypeAttribute(typeof(ExternalPageCover))]
    public interface IPageCover
    {
        [JsonProperty("type")]
        string Type { get; set; }
    }
}
