using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class QueryDataSourceResponse : PaginatedList<IQueryDataSourceResponseObject>
    {
        [JsonProperty("page_or_data_source")]
        public Dictionary<string, object> PageOrDataSource { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
