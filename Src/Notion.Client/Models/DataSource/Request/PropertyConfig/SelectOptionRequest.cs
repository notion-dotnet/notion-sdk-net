using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class SelectOptionRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Additional data for future compatibility
        /// If you encounter properties that are not yet supported, please open an issue on GitHub.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}