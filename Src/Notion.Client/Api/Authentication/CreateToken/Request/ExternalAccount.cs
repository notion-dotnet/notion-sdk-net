using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// External account info
    /// </summary>
    public class ExternalAccount
    {
        /// <summary>
        /// External account key
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// External account name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
