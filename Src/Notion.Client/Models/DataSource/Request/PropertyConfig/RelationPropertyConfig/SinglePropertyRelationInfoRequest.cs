using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class SinglePropertyRelationInfoRequest : IRelationInfoRequest
    {
        public string DataSourceId { get; set; }

        [JsonProperty("type")]
        public string Type => "single_property";

        [JsonProperty("single_property")]
        public IDictionary<string, object> SingleProperty { get; set; }

        /// <summary>
        /// Additional data for future compatibility
        /// If you encounter properties that are not yet supported, please open an issue on GitHub.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
