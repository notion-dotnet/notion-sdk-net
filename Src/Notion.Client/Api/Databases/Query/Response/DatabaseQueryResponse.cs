using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class DatabaseQueryResponse : PaginatedList<IWikiDatabase>
    {
        [JsonProperty("database")]
        public Dictionary<string, object> Database { get; set; }
    }
}
