using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class PeopleDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "people";

        [JsonProperty("people")]
        public IDictionary<string, object> People { get; set; }
    }
}