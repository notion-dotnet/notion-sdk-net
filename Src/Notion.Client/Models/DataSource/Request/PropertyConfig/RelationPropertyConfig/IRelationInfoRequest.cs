using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IRelationInfoRequest
    {
        [JsonProperty("data_source_id")]
        string DataSourceId { get; set; }

        [JsonProperty("type")]
        string Type { get; }

        /// <summary>
        /// Additional data for future compatibility
        /// If you encounter properties that are not yet supported, please open an issue on GitHub.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
