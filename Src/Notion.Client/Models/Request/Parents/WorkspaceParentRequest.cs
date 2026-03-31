using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class WorkspaceParentRequest : IParentOfPageRequest
    {
        [JsonProperty("type")]
        public string Type => "workspace";

        [JsonProperty("workspace")]
        public bool Workspace => true;

        /// <summary>
        /// Additional data for future compatibility
        /// If you encounter properties that are not yet supported, please open an issue on GitHub.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
