using Newtonsoft.Json;

namespace Notion.Client
{
    public class TableBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.Table;

        [JsonProperty("table")]
        public TableInfo Table { get; set; }

        public class TableInfo
        {
            [JsonProperty("table_width")]
            public int TableWidth { get; set; }

            [JsonProperty("has_column_header")]
            public bool HasColumnHeader { get; set; }

            [JsonProperty("has_row_header")]
            public bool HasRowHeader { get; set; }

            [JsonProperty("children")]
            public TableRowBlock Children { get; set; }
        }
    }
}
