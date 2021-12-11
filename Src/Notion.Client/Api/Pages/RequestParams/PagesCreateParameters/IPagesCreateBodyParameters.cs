using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IPagesCreateBodyParameters
    {
        [JsonProperty("parent")]
        IPageParentInput Parent { get; set; }

        [JsonProperty("properties")]
        IDictionary<string, PropertyValue> Properties { get; set; }

        [JsonProperty("children")]
        IList<IBlock> Children { get; set; }

        [JsonProperty("icon")]
        IPageIcon Icon { get; set; }

        [JsonProperty("cover")]
        FileObject Cover { get; set; }
    }
}
