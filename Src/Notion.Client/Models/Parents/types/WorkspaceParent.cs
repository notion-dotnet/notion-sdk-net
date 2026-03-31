using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class WorkspaceParent : IParentOfDatabase, IParentOfBlock, IParentOfPage
    {
        public string Type { get; set; } = ParentTypes.Workspace;

        [JsonProperty(ParentTypes.Workspace)]
        public bool Workspace { get; set; } = true;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
