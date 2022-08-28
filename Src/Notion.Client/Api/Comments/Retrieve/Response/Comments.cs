using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class RetrieveCommentsResponse : PaginatedList<Comment>
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("comment")]
        public Dictionary<string, object> Comment { get; set; }
    }
}
