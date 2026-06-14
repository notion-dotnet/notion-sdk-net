using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IBlockObjectRequest : IObject, IObjectModificationData
    {
        [JsonProperty("type")]
        BlockType Type { get; }

        [JsonProperty("has_children")]
        bool HasChildren { get; set; }

        [JsonProperty("parent")]
        IParentOfBlock Parent { get; set; }
    }
}
