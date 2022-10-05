using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class RollupPropertyItem : SimplePropertyItem
    {
        public override string Type => "rollup";

        [JsonProperty("rollup")]
        public Data Rollup { get; set; }

        public class Data
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("function")]
            public string Function { get; set; }

            [JsonProperty("number")]
            public double? Number { get; set; }

            [JsonProperty("date")]
            public Date Date { get; set; }

            [JsonProperty("array")]
            public IEnumerable<Dictionary<string, object>> Array { get; set; }

            [JsonProperty("unsupported")]
            public Dictionary<string, object> Unsupported { get; set; }

            [JsonProperty("incomplete")]
            public Dictionary<string, object> Incomplete { get; set; }
        }
    }
}
