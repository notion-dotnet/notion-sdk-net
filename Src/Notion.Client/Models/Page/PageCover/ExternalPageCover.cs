using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ExternalPageCover : IPageCover
    {
        [JsonProperty("type")]
        public string Type { get; set; } = "external";

        [JsonProperty("external")]
        public ExternalFileInfo External { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
