using Newtonsoft.Json;

namespace Notion.Client
{
    public class WorkspaceParentOfDatabaseRequest : IParentOfDatabaseRequest
    {
        [JsonProperty("type")]
        public string Type => "workspace";

        [JsonProperty("workspace")]
        public bool Workspace => true;
    }
}
