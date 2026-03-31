using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CheckboxDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.Checkbox;

        [JsonProperty("checkbox")]
        public Dictionary<string, object> Checkbox { get; set; }
    }
}
