using System.Collections.Generic;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(RollupPropertyItem), "rollup")]
    [JsonSubtypes.FallBackSubType(typeof(ListPropertyItem))]
    public class ListPropertyItem : IPropertyItemObject
    {
        public string Object => "list";
        public virtual string Type { get; set; }

        [JsonProperty("results")]
        public IEnumerable<SimplePropertyItem> Results { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }
    }
}
