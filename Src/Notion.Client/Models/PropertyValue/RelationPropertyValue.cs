using System.Collections.Generic;

namespace Notion.Client
{
    public class RelationPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Relation;

        /// <summary>
        /// Array of page references
        /// </summary>
        public List<ObjectId> Relation { get; set; }
    }
}
