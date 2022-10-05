using Newtonsoft.Json;

namespace Notion.Client
{
    public class BreadcrumbUpdateBlock : IUpdateBlock
    {
        public BreadcrumbUpdateBlock()
        {
            Breadcrumb = new Info();
        }

        [JsonProperty("breadcrumb")]
        public Info Breadcrumb { get; set; }

        public bool Archived { get; set; }

        public class Info
        {
        }
    }
}
