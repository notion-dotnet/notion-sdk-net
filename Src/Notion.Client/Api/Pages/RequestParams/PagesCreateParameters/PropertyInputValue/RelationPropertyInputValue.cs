using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Relation property value object.
    /// </summary>
    public class RelationPropertyInputValue : PropertyInputValue
    {
        /// <summary>
        /// Array of page references
        /// </summary>
        [JsonProperty("relation")]
        public List<ObjectId> Relation { get; set; }
    }
}
