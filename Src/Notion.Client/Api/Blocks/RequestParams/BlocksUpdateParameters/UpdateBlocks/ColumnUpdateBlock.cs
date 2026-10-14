using Newtonsoft.Json;

namespace Notion.Client
{
    public class ColumnUpdateBlock : UpdateBlock
    {
        [JsonProperty("column")]
        public Info Column { get; set; }

        public class Info
        {
            /// <summary>
            /// Ratio between 0 and 1 of the width of this column relative to all columns in the list.
            /// If not provided, the width is left unchanged.
            /// </summary>
            [JsonProperty("width_ratio")]
            public double? WidthRatio { get; set; }
        }
    }
}
