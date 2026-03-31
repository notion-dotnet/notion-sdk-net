using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class EmailDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.Email;

        [JsonProperty("email")]
        public Dictionary<string, object> Email { get; set; }
    }
}
