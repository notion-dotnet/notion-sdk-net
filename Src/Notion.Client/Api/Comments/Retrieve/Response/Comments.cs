using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class RetrieveCommentsResponse : PaginatedList<Comment>
    {
        [JsonProperty("comment")]
        public Dictionary<string, object> Comment { get; set; }
    }
}
