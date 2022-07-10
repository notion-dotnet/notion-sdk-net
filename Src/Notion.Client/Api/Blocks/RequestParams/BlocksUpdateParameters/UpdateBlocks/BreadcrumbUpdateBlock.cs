using Newtonsoft.Json;

namespace Notion.Client
{
    public class BreadcrumbUpdateBlock : IUpdateBlock
    {
        public bool Archived { get; set; }

        [JsonProperty("breadcrumb")]
        public Info Breadcrumb { get; set; }

        public class Info
        {
        }

        public BreadcrumbUpdateBlock()
        {
            Breadcrumb = new Info();
        }
    }
}
