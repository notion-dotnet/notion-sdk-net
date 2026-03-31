using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class RichTextDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.RichText;

        [JsonProperty("rich_text")]
        public Dictionary<string, object> RichText { get; set; }
    }
}
