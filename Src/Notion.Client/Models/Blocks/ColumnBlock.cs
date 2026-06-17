using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ColumnBlock : Block
    {
        public override BlockType Type => BlockType.Column;

        [JsonProperty("column")]
        public Info Column { get; set; }

        public class Info
        {
            [JsonProperty("children")]
            public IEnumerable<IColumnChildrenBlock> Children { get; set; }

            /// <summary>
            /// Proportional width of this column relative to its siblings.
            /// For example, a value of 0.25 means this column takes 25% of the available width.
            /// </summary>
            [JsonProperty("width_ratio")]
            public double? WidthRatio { get; set; }
        }
    }
}
