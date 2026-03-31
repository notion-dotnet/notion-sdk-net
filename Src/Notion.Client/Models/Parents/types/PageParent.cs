using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class PageParent : IParentOfDatabase, IParentOfBlock, IParentOfPage, IParentOfComment
    {
        public string Type { get; set; } = ParentTypes.Page;

        [JsonProperty(ParentTypes.Page)]
        public string PageId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
