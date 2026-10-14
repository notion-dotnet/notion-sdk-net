using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class QueryDataSourceResponse : PaginatedList<IQueryDataSourceResponseObject>
    {
        [JsonProperty("page_or_data_source")]
        public Dictionary<string, object> PageOrDataSource { get; set; }

        /// <summary>
        /// Whether the query ran to completion. When the result limit is reached the status is
        /// <see cref="QueryDataSourceRequestStatus.Incomplete" /> and the results are truncated.
        /// </summary>
        [JsonProperty("request_status")]
        public QueryDataSourceRequestStatus RequestStatus { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }

    public class QueryDataSourceRequestStatus
    {
        public const string Complete = "complete";
        public const string Incomplete = "incomplete";
        public const string QueryResultLimitReached = "query_result_limit_reached";

        /// <summary>
        /// "complete" or "incomplete".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Why the query is incomplete, e.g. "query_result_limit_reached".
        /// </summary>
        [JsonProperty("incomplete_reason")]
        public string IncompleteReason { get; set; }

        [JsonIgnore]
        public bool IsIncomplete => Type == Incomplete;
    }
}
