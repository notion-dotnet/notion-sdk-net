using Newtonsoft.Json;

namespace Notion.Client
{
    public class BreadcrumbBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
    {
        [JsonProperty("breadcrumb")]
        public Data Breadcrumb { get; set; }

        public override BlockType Type => BlockType.Breadcrumb;

        public class Data
        {
        }
    }
}
