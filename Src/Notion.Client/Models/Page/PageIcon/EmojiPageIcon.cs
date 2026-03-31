using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class EmojiPageIcon : IPageIcon
    {
        public string Type { get; set; } = PageIconTypes.Emoji;

        [JsonProperty(PageIconTypes.Emoji)]
        public string Emoji { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
