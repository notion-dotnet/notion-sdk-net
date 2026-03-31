using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PageParent), ParentTypes.Page)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(BlockParent), ParentTypes.Block)]
    public interface IParentOfComment
    {
        [JsonProperty("type")]
        string Type { get; set; }
    }
}
