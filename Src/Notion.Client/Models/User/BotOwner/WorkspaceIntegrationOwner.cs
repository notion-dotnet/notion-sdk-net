using Newtonsoft.Json;

namespace Notion.Client
{
    public class WorkspaceIntegrationOwner : IBotOwner
    {
        [JsonProperty("workspace")]
        public bool Workspace { get; set; }

        public string Type { get; set; }
    }
}
