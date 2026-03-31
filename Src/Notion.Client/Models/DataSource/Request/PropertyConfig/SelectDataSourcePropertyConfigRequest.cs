using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class SelectDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "select";

        [JsonProperty("select")]
        public SelectOptions Select { get; set; }

        public class SelectOptions
        {
            [JsonProperty("options")]
            public IEnumerable<SelectOptionRequest> Options { get; set; }

            /// <summary>
            /// Additional data for future compatibility
            /// If you encounter properties that are not yet supported, please open an issue on GitHub.
            /// </summary>
            [JsonExtensionData]
            public IDictionary<string, object> AdditionalData { get; set; }
        }
    }
}