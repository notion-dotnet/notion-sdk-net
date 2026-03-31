using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ExternalFileInfo
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
