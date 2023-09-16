using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IDatabaseQueryQueryParameters
    {
        [JsonProperty("filter_properties")]
        List<string> FilterProperties { get; set; }
    }
}
