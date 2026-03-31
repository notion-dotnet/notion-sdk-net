using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public interface IBlockObjectRequest : IObject, IObjectModificationData
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        BlockType Type { get; }

        [JsonProperty("has_children")]
        bool HasChildren { get; set; }

        [JsonProperty("parent")]
        IParentOfBlock Parent { get; set; }
    }
}
