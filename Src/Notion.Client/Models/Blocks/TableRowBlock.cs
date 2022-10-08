using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TableRowBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("table_row")]
        public Info TableRow { get; set; }

        public override BlockType Type => BlockType.TableRow;

        public class Info
        {
            [JsonProperty("cells")]
            public IEnumerable<IEnumerable<RichTextText>> Cells { get; set; }
        }
    }
}
