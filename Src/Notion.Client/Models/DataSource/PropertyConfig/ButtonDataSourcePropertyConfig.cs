using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ButtonDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.Button;

        [JsonProperty("button")]
        public Dictionary<string, object> Button { get; set; }
    }
}
