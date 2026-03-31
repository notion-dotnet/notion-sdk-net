using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IPagesCreateBodyParameters
    {
        [JsonProperty("parent")]
        IParentOfPageRequest Parent { get; set; }

        [JsonProperty("properties")]
        IDictionary<string, PropertyValue> Properties { get; set; }

        [JsonProperty("children")]
        IList<IBlock> Children { get; set; }

        [JsonProperty("icon")]
        IPageIconRequest Icon { get; set; }

        [JsonProperty("cover")]
        IPageCoverRequest Cover { get; set; }
    }
}
