using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(ExternalPageCover), "external")]
    [JsonSubtypes.KnownSubType(typeof(FilePageCover), "file")]
    [JsonSubtypes.FallBackSubTypeAttribute(typeof(ExternalPageCover))]
    public interface IPageCover
    {
        [JsonProperty("type")]
        string Type { get; set; }
    }
}
