using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(UserOwner), "user")]
    [JsonSubtypes.KnownSubType(typeof(WorkspaceIntegrationOwner), "workspace")]
    public interface IBotOwner
    {
        [JsonProperty("type")]
        string Type { get; set; }
    }
}
