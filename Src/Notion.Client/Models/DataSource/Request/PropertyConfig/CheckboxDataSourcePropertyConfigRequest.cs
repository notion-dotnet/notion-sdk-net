using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CheckboxDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "checkbox";

        [JsonProperty("checkbox")]
        public IDictionary<string, object> Checkbox { get; set; }
    }
}