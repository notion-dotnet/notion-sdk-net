using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IPaginationParameters
    {
        [JsonProperty("start_cursor")]
        string StartCursor { get; set; }

        [JsonProperty("page_size")]
        string PageSize { get; set; }
    }

    public class PaginatedList<T>
    {
        public const string Object = "list";

        public List<T> Results { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }
    }
}
