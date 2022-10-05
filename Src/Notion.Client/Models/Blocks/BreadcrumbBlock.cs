using Newtonsoft.Json;

namespace Notion.Client
{
    public class BreadcrumbBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("breadcrumb")]
        public Data Breadcrumb { get; set; }

        public override BlockType Type => BlockType.Breadcrumb;

        public class Data
        {
        }
    }
}
