using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TitleDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "title";

        [JsonProperty("title")]
        public IDictionary<string, object> Title { get; set; }
    }
}