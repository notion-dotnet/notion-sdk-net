using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Relation property value object.
    /// </summary>
    public class RelationPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Relation;

        /// <summary>
        ///     Array of page references
        /// </summary>
        [JsonProperty("relation")]
        public List<ObjectId> Relation { get; set; }
    }
}
