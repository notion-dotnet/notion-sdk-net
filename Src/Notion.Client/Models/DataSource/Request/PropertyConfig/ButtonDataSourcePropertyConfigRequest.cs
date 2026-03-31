using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ButtonDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "button";

        [JsonProperty("button")]
        public IDictionary<string, object> Button { get; set; }
    }
}