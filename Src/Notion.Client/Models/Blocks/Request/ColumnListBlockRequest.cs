using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ColumnListBlockRequest : BlockObjectRequest, INonColumnBlockRequest
    {
        [JsonProperty("column_list")]
        public Info ColumnList { get; set; }

        public override BlockType Type => BlockType.ColumnList;

        public class Info
        {
            [JsonProperty("children")]
            public IEnumerable<ColumnBlockRequest> Children { get; set; }
        }
    }
}
