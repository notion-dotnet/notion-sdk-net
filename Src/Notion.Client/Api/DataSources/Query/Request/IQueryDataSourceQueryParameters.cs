using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IQueryDataSourceQueryParameters
    {
        /// <summary>
        /// List of properties to filter the results by.
        /// </summary>
        [JsonProperty("filter_properties")]
        IEnumerable<string> FilterProperties { get; set; }
    }
}
