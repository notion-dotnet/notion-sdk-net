using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class StatusDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.Status;

        [JsonProperty("status")]
        public StatusConfig Status { get; set; }
    }

    public class StatusConfig
    {
        [JsonProperty("options")]
        public IEnumerable<StatusOption> Options { get; set; }

        [JsonProperty("groups")]
        public IEnumerable<StatusGroup> Groups { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }

    public class StatusOption
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public Color? Color { get; set; }
    }

    public class StatusGroup
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public Color? Color { get; set; }

        [JsonProperty("option_ids")]
        public IEnumerable<string> OptionIds { get; set; }
    }
}
