using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ExternalPageIconRequest : IPageIconRequest
    {
        [JsonProperty("type")]
        public string Type => "external";

        [JsonProperty("external")]
        public ExternalUrl External { get; set; }

        /// <summary>
        /// Additional data for future compatibility
        /// If you encounter properties that are not yet supported, please open an issue on GitHub.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }

        public class ExternalUrl
        {
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Additional data for future compatibility
            /// If you encounter properties that are not yet supported, please open an issue on GitHub.
            /// </summary>
            [JsonExtensionData]
            public IDictionary<string, object> AdditionalData { get; set; }
        }
    }
}
