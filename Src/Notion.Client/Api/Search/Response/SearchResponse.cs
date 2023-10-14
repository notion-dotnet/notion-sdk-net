using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class SearchResponse : PaginatedList<IObject>
    {
        [JsonProperty("page_or_database")]
        public Dictionary<string, object> PageOrDatabase { get; set; }
    }
}
