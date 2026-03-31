using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class UrlDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "url";

        [JsonProperty("url")]
        public IDictionary<string, object> Url { get; set; }
    }
}