using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IRevokeTokenBodyParameters
    {
        /// <summary>
        /// The token to be revoked.
        /// </summary>
        [JsonProperty("token")]
        string Token { get; set; }
    }
}
