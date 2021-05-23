using Newtonsoft.Json;
using System.Collections.Generic;

namespace Notion.Client
{
    public interface IPaginationParameters
    {
        string StartCursor { get; set; }
        string PageSize { get; set; }
    }

    public class PaginatedList<T>
    {
        public const string Object = "List";

        public List<T> Results { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }
    }
}
