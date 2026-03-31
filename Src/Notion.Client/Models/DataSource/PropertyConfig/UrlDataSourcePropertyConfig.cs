using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class UrlDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.Url;

        [JsonProperty("url")]
        public Dictionary<string, object> Url { get; set; }
    }
}
