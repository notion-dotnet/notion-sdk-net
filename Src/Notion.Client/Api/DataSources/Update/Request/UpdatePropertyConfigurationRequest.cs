using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(UpdatePropertyConfigurationRequestConverterFactory))]
    public class UpdatePropertyConfigurationRequest<T> : IUpdatePropertyConfigurationRequest where T : DataSourcePropertyConfigRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The property configuration details.
        /// 
        /// This object will get flattened into the parent object when serialized.
        /// If null or not provided, the property configuration will remain unchanged.
        /// </summary>
        public T PropertyRequest { get; set; }
    }
}
