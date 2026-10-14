using Newtonsoft.Json;

namespace Notion.Client
{
    public class Bot
    {
        [JsonProperty("owner")]
        public IBotOwner Owner { get; set; }

        /// <summary>
        ///     The ID of the bot's workspace.
        /// </summary>
        [JsonProperty("workspace_id")]
        public string WorkspaceId { get; set; }

        /// <summary>
        ///     The name of the bot's workspace.
        /// </summary>
        [JsonProperty("workspace_name")]
        public string WorkspaceName { get; set; }

        /// <summary>
        ///     Limits and restrictions that apply to the bot's workspace.
        /// </summary>
        [JsonProperty("workspace_limits")]
        public WorkspaceLimits WorkspaceLimits { get; set; }
    }
}
