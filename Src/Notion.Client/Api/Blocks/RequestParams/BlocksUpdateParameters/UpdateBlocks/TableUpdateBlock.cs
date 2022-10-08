using Newtonsoft.Json;

namespace Notion.Client
{
    public class TableUpdateBlock : UpdateBlock
    {
        [JsonProperty("table")]
        public Info Table { get; set; }

        public class Info
        {
            [JsonProperty("has_column_header")]
            public bool HasColumnHeader { get; set; }

            [JsonProperty("has_row_header")]
            public bool HasRowHeader { get; set; }
        }
    }
}
