using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TableBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("table")]
        public Info Table { get; set; }

        public override BlockType Type => BlockType.Table;

        public class Info
        {
            [JsonProperty("table_width")]
            public int TableWidth { get; set; }

            [JsonProperty("has_column_header")]
            public bool HasColumnHeader { get; set; }

            [JsonProperty("has_row_header")]
            public bool HasRowHeader { get; set; }

            [JsonProperty("children")]
            public IEnumerable<TableRowBlock> Children { get; set; }
        }
    }
}
