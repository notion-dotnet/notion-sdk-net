using Newtonsoft.Json;

namespace Notion.Client
{
    public class DividerBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
    {
        [JsonProperty("divider")]
        public Data Divider { get; set; }

        public override BlockType Type => BlockType.Divider;

        public class Data
        {
        }
    }
}
