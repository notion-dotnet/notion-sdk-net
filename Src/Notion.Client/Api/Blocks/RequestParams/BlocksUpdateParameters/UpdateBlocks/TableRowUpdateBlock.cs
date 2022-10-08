using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TableRowUpdateBlock : UpdateBlock
    {
        [JsonProperty("table_row")]
        public Info TableRow { get; set; }

        public class Info
        {
            [JsonProperty("cells")]
            public IEnumerable<IEnumerable<RichTextTextInput>> Cells { get; set; }
        }
    }
}
