using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public interface IQueryDataSourceBodyParameters : IPaginationParameters
    {
        /// <summary>
        /// A list of sort objects to apply to the query results.
        /// </summary>
        [JsonProperty("sorts")]
        IEnumerable<Sort> Sorts { get; set; }

        /// <summary>
        /// A filter object to apply to the query results.
        /// </summary>
        [JsonProperty("filter")]
        Filter Filter { get; set; }

        /// <summary>
        /// Whether to include archived results.
        /// </summary>
        [JsonProperty("archived")]
        bool? Archived { get; set; }

        /// <summary>
        /// Whether to include results in trash.
        /// </summary>
        [JsonProperty("in_trash")]
        bool? InTrash { get; set; }

        /// <summary>
        /// Optionally filter the results to only include pages or data sources.
        /// </summary>
        [JsonProperty("result_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        QueryResultType? ResultType { get; set; }
    }
}
