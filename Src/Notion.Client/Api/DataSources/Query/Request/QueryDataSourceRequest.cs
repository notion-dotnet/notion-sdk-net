using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class QueryDataSourceRequest : IQueryDataSourcePathParameters, IQueryDataSourceQueryParameters, IQueryDataSourceBodyParameters
    {
        /// <summary>
        /// The ID of the data source to query.
        /// </summary>
        public string DataSourceId { get; set; }

        public IEnumerable<string> FilterProperties { get; set; }

        /// <summary>
        /// A list of sort objects to apply to the query results.
        /// </summary>
        [JsonProperty("sorts")]
        public IEnumerable<Sort> Sorts { get; set; }

        /// <summary>
        /// A filter object to apply to the query results.
        /// </summary>
        [JsonProperty("filter")]
        public Filter Filter { get; set; }

        /// <summary>
        /// When supplied, returns a page of results starting after the cursor provided.
        /// </summary>
        [JsonProperty("start_cursor")]
        public string StartCursor { get; set; }

        /// <summary>
        /// The number of items from the full list desired in the response. Maximum: 100.
        /// </summary>
        [JsonProperty("page_size")]
        public int? PageSize { get; set; }

        /// <summary>
        /// Whether to include archived results.
        /// </summary>
        [JsonProperty("archived")]
        public bool? Archived { get; set; }

        /// <summary>
        /// Whether to include results in trash.
        /// </summary>
        [JsonProperty("in_trash")]
        public bool? InTrash { get; set; }

        /// <summary>
        /// Optionally filter the results to only include pages or data sources.
        /// Regular, non-wiki databases only support page children. The default behavior
        /// is no result type filtering, returning both pages and data sources for wikis.
        /// </summary>
        [JsonProperty("result_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public QueryResultType? ResultType { get; set; }
    }
}
