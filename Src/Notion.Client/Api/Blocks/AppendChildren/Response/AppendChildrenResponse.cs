using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class AppendChildrenResponse : PaginatedList<IBlock>
    {
        [JsonProperty("block")]
        public Dictionary<string, object> Block { get; set; }
    }
}
