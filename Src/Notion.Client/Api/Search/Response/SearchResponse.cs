using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class SearchResponse : PaginatedList<ISearchResponseObject>
    {
        [JsonProperty("page_or_database")]
        public Dictionary<string, object> PageOrDatabase { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
