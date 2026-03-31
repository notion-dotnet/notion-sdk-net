using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class UniqueIdDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "unique_id";

        [JsonProperty("unique_id")]
        public UniqueIdConfiguration UniqueId { get; set; }

        public class UniqueIdConfiguration
        {
            [JsonProperty("prefix")]
            public string Prefix { get; set; }

            /// <summary>
            /// Additional data for future compatibility
            /// If you encounter properties that are not yet supported, please open an issue on GitHub.
            /// </summary>
            [JsonExtensionData]
            public IDictionary<string, object> AdditionalData { get; set; }
        }
    }
}