using Newtonsoft.Json;

namespace Notion.Client
{
    public class DataSourceTemplate
    {
        /// <summary>
        /// The unique identifier of the data source template.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the data source template.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Indicates whether the template is the default template for the data source.
        /// </summary>
        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }
    }
}
