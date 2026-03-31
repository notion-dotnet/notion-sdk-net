using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    /// <summary>
    /// Internal concrete implementation of IQueryDataSourceBodyParameters used for JSON serialization.
    /// This class contains only the properties that should be serialized in the request body.
    /// </summary>
    internal class QueryDataSourceBodyRequest : IQueryDataSourceBodyParameters
    {
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
        /// </summary>
        [JsonProperty("result_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public QueryResultType? ResultType { get; set; }

        /// <summary>
        /// Creates a QueryDataSourceBodyRequest from a QueryDataSourceRequest
        /// </summary>
        /// <param name="source">The source request containing all parameters</param>
        /// <returns>A new QueryDataSourceBodyRequest with only body parameters</returns>
        internal static QueryDataSourceBodyRequest FromRequest(QueryDataSourceRequest source)
        {
            return new QueryDataSourceBodyRequest
            {
                Sorts = source.Sorts,
                Filter = source.Filter,
                StartCursor = source.StartCursor,
                PageSize = source.PageSize,
                Archived = source.Archived,
                InTrash = source.InTrash,
                ResultType = source.ResultType
            };
        }
    }
}