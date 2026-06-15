using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ListEmojisResponse : PaginatedList<CustomEmoji>
    {
        [JsonProperty("custom_emoji")]
        public Dictionary<string, object> CustomEmoji { get; set; }
    }
}
