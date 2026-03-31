using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class DataSourceParentRequest : IParentOfPageRequest, IParentOfDataSourceRequest
    {
        [JsonProperty("type")]
        public string Type => "data_source_id";

        [JsonProperty("data_source_id")]
        public string DataSourceId { get; set; }

        [JsonProperty("database_id")]
        public string DatabaseId { get; set; }

        /// <summary>
        /// Additional data for future compatibility
        /// If you encounter properties that are not yet supported, please open an issue on GitHub.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
