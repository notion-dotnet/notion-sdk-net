using Newtonsoft.Json;

namespace Notion.Client
{
    public class CreateTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; } = "bearer";

        [JsonProperty("bot_id")]
        public string BotId { get; set; }

        [JsonProperty("duplicated_template_id")]
        public string DuplicatedTemplateId { get; set; }

        [JsonProperty("owner")]
        public IBotOwner Owner { get; set; }

        [JsonProperty("workspace_icon")]
        public string WorkspaceIcon { get; set; }

        [JsonProperty("workspace_id")]
        public string WorkspaceId { get; set; }

        [JsonProperty("workspace_name")]
        public string WorkspaceName { get; set; }
    }
}
