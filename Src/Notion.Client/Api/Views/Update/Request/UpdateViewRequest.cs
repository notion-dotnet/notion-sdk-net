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
