using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class InternalFileInfo
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("expiry_time")]
        public DateTime ExpiryTime { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
