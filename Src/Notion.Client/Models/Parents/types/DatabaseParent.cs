using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class DatabaseParent : IParentOfDatasource, IParentOfDatabase, IParentOfBlock, IParentOfPage
    {
        public string Type { get; set; } = ParentTypes.Database;

        [JsonProperty(ParentTypes.Database)]
        public string DatabaseId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
