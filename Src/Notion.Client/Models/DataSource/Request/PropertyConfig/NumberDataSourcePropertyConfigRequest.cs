using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class NumberDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "number";

        [JsonProperty("number")]
        public NumberFormat Number { get; set; }

        public class NumberFormat
        {
            [JsonProperty("format")]
            public string Format { get; set; }

            /// <summary>
            /// Additional data for future compatibility
            /// If you encounter properties that are not yet supported, please open an issue on GitHub.
            /// </summary>
            [JsonExtensionData]
            public IDictionary<string, object> AdditionalData { get; set; }
        }
    }
}