using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(EmojiPageIcon), PageIconTypes.Emoji)]
    [JsonSubtypes.KnownSubType(typeof(CustomEmojiPageIcon), PageIconTypes.CustomEmoji)]
    [JsonSubtypes.KnownSubType(typeof(FilePageIcon), PageIconTypes.File)]
    [JsonSubtypes.KnownSubType(typeof(ExternalPageIcon), PageIconTypes.External)]
    public interface IPageIcon
    {
        [JsonProperty("type")]
        string Type { get; set; }
    }
}
