using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(FilePageCover), "file")]
    [JsonSubtypes.KnownSubType(typeof(ExternalPageCover), "external")]
    public interface IPageCover
    {
        [JsonProperty("type")]
        string Type { get; set; }
    }
}
