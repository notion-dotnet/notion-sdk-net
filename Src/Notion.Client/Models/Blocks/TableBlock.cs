﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    internal class TableBlock : Block
    {
        public override BlockType Type => BlockType.Table;

        [JsonProperty("table")]
        public Info Table { get; set; }

        public class Info
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
