using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IPagesUpdateBodyParameters
    {
        [JsonProperty("icon")]
        IPageIconRequest Icon { get; set; }

        [JsonProperty("cover")]
        IPageCoverRequest Cover { get; set; }

        [JsonProperty("in_trash")]
        bool InTrash { get; set; }

        [JsonProperty("properties")]
        IDictionary<string, PropertyValue> Properties { get; set; }
    }
}
