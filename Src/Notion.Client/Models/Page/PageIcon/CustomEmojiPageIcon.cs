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

    public class IconPageIcon : IPageIcon
    {
        public string Type { get; set; } = PageIconTypes.Icon;
        
        [JsonProperty(PageIconTypes.Icon)]
        public IconObject Icon { get; set; }
        
        public class IconObject
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("color")]
            public string Color { get; set; }

            [JsonExtensionData]
            public IDictionary<string, object> AdditionalData { get; set; }
        }
    }
}
