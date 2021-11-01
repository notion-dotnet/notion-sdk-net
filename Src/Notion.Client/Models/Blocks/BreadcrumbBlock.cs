using Newtonsoft.Json;

namespace Notion.Client
{
    public class BreadcrumbBlock : Block
    {
        public override BlockType Type => BlockType.Breadcrumb;

        [JsonProperty("breadcrumb")]
        public Data Breadcrumb { get; set; }

        public class Data
        {
        }
    }
}
