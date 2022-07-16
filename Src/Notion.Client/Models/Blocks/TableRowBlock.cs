using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TableRowBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.TableRow;

        [JsonProperty("table_row")]
        public Info TableRow { get; set; }

        public class Info
        {
            [JsonProperty("cells")]
            public IEnumerable<IEnumerable<RichTextText>> Cells { get; set; }
        }
    }
}
