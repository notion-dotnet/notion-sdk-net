using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class FormulaDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.Formula;

        [JsonProperty("formula")]
        public FormulaResponse Formula { get; set; }
    }

    public class FormulaResponse
    {
        [JsonProperty("expression")]
        public string Expression { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
