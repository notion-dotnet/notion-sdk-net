using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class NumberDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.Number;

        [JsonProperty("number")]
        public NumberResponse Number { get; set; }
    }

    public class NumberResponse
    {
        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
