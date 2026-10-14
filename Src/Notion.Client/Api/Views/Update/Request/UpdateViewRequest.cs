using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class UpdateViewRequest
    {
        /// <summary>
        /// The ID of the view to update. This is a path parameter and is not serialized in the request body.
        /// </summary>
        [JsonIgnore]
        public string ViewId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("filter")]
        public object Filter { get; set; }

        [JsonProperty("sorts")]
        public IEnumerable<UpdateViewSort> Sorts { get; set; }

        /// <summary>
        /// Quick filters for the view's filter bar. Keys are property names or ids. Set a key to a filter condition to
        /// add or update that quick filter, or to <c>null</c> to remove it. Quick filters that are not mentioned are kept.
        /// </summary>
        [JsonProperty("quick_filters")]
        public IDictionary<string, object> QuickFilters { get; set; }

        [JsonProperty("configuration")]
        public ViewConfiguration Configuration { get; set; }
    }

    public class UpdateViewSort
    {
        [JsonProperty("property")]
        public string Property { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }
    }
}
