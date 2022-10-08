using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(EmojiObject), "emoji")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FileObject), "file")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FileObject), "external")]
    public interface IPageIcon
    {
        [JsonProperty("type")]
        string Type { get; set; }
    }
}
