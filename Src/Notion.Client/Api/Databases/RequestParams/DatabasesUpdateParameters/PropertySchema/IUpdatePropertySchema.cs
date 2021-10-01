using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public interface IUpdatePropertySchema
    {
        [JsonProperty("name")]
        string Name { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        PropertyType? Type { get; set; }
    }

    public abstract class UpdatePropertySchema : IUpdatePropertySchema
    {
        public string Name { get; set; }

        public PropertyType? Type { get; set; }
    }
}
