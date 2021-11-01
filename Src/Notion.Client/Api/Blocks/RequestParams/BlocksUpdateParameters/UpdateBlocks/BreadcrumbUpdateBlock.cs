using Newtonsoft.Json;

namespace Notion.Client
{
    public class BreadcrumbUpdateBlock : IUpdateBlock
    {
        public bool Archived { get; set; }

        [JsonProperty("breadcrumb")]
        public Data Breadcrumb { get; set; }

        public class Data
        {
        }

        public BreadcrumbUpdateBlock()
        {
            Breadcrumb = new Data();
        }
    }
}
