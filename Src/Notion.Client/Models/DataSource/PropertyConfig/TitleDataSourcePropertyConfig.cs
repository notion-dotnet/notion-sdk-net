using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TitleDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.Title;

        [JsonProperty("title")]
        public Dictionary<string, object> Title { get; set; }
    }
}
