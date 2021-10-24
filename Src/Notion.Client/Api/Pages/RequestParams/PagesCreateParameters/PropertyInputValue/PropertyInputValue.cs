using Newtonsoft.Json;

namespace Notion.Client
{
    public abstract class PropertyInputValue
    {
        /// <summary>
        /// Underlying identifier of the property.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
