using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ColumnBlockRequest : BlockObjectRequest
    {
        public override BlockType Type => BlockType.Column;

        [JsonProperty("column")]
        public Info Column { get; set; }

        public class Info
        {
            [JsonProperty("children")]
            public IEnumerable<IColumnChildrenBlockRequest> Children { get; set; }

            /// <summary>
            /// Proportional width of this column relative to its siblings.
            /// </summary>
            [JsonProperty("width_ratio")]
            public double? WidthRatio { get; set; }
        }
    }
}
