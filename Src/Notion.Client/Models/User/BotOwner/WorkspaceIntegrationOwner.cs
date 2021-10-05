using Newtonsoft.Json;

namespace Notion.Client
{
    public class WorkspaceIntegrationOwner : IBotOwner
    {
        public string Type { get; set; }

        [JsonProperty("workspace")]
        public bool Workspace { get; set; }
    }
}
