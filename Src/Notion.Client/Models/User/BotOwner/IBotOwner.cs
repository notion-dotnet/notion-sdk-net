using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(UserOwner), "user")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(WorkspaceIntegrationOwner), "workspace")]
    [JsonSubtypes.FallBackSubTypeAttribute(typeof(WorkspaceIntegrationOwner))]
    public interface IBotOwner
    {
        [JsonProperty("type")]
        string Type { get; set; }
    }
}
