using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class EmailDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "email";

        [JsonProperty("email")]
        public IDictionary<string, object> Email { get; set; }
    }
}