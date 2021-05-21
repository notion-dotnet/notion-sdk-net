using Newtonsoft.Json;
using System.Collections.Generic;

namespace Notion.Client
{
    public class PaginatedList<T>
    {
        public List<T> Results { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }
    }
}
