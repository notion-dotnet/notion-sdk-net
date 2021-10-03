using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(EmojiObject), "emoji")]
    [JsonSubtypes.KnownSubType(typeof(FileObject), "file")]
    [JsonSubtypes.KnownSubType(typeof(FileObject), "external")]
    public interface IPageIcon
    {
        [JsonProperty("type")]
        string Type { get; set; }
    }
}
