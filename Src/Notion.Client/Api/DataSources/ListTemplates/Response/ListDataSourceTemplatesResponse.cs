using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ListDataSourceTemplatesResponse
    {
        /// <summary>
        /// A collection of data source templates.
        /// </summary>
        [JsonProperty("templates")]
        public IEnumerable<DataSourceTemplate> Templates { get; set; }

        /// <summary>
        /// Indicates whether there are more templates to retrieve.
        /// </summary>
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        /// <summary>
        /// The cursor to use for fetching the next page of templates.
        /// </summary>
        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }
    }
}
