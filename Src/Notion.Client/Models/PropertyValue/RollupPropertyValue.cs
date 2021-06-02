using System.Collections.Generic;

namespace Notion.Client
{
    public class RollupPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Rollup;

        public RollupValue Rollup { get; set; }
    }

    public class RollupValue
    {
        public string Type { get; set; }
        public double Number { get; set; }
        public DatePropertyValue Date { get; set; }

        /// <summary>
        /// Array containing the propert value object will not contain value for Id field
        /// </summary>
        public List<PropertyValue> Array { get; set; }
    }
}
