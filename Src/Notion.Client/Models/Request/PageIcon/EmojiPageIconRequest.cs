using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class EmojiPageIconRequest : IPageIconRequest
    {
        [JsonProperty("type")]
        public string Type => "emoji";

        [JsonProperty("emoji")]
        public string Emoji { get; set; }

        /// <summary>
        /// Additional data for future compatibility
        /// If you encounter properties that are not yet supported, please open an issue on GitHub.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
