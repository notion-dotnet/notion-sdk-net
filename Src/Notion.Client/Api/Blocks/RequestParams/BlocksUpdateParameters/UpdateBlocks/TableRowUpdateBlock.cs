using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TableRowUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("table_row")]
        public Info TableRow { get; set; }

        public class Info
        {
            [JsonProperty("cells")]
            public TextContentUpdate Cells { get; set; }
        }
    }
}
