using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CustomEmojiPageIcon : IPageIcon
    {
        public string Type { get; set; } = PageIconTypes.CustomEmoji;

        [JsonProperty(PageIconTypes.CustomEmoji)]
        public CustomEmoji CustomEmoji { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
