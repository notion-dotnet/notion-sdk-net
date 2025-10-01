using Newtonsoft.Json;

namespace Notion.Client
{
    public class RefreshTokenResponse
    {
        /// <summary>
        /// A unique token that you can use to authenticate requests to the Notion API.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// A unique token that you can use to refresh your access token when it expires.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// The unique identifier for the integration associated with the access token.
        /// </summary>
        [JsonProperty("bot_id")]
        public string BotId { get; set; }

        /// <summary>
        /// Duplicated template id
        /// </summary>
        [JsonProperty("duplicated_template_id")]
        public string DuplicatedTemplateId { get; set; }

        /// <summary>
        /// The type of owner for the integration. This will always be "workspace".
        /// </summary>
        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        /// <summary>
        /// The icon of the workspace the integration is connected to. This will be null if the workspace has no icon.
        /// </summary>
        [JsonProperty("workspace_icon")]
        public string WorkspaceIcon { get; set; }

        /// <summary>
        /// The name of the workspace the integration is connected to.
        /// </summary>
        [JsonProperty("workspace_name")]
        public string WorkspaceName { get; set; }

        /// <summary>
        /// The unique identifier of the workspace the integration is connected to.
        /// </summary>
        [JsonProperty("workspace_id")]
        public string WorkspaceId { get; set; }
    }
}
