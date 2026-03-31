using Newtonsoft.Json;

namespace Notion.Client
{
    public class IntrospectTokenResponse
    {
        [JsonProperty("active")]
        public bool IsActive { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("iat")]
        public long Iat { get; set; }
    }
}
