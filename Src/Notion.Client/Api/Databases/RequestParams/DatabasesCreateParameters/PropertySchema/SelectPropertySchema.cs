using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class SelectPropertySchema : IPropertySchema
    {
        public OptionWrapper<SelectOptionSchema> Select { get; set; }
    }

    public class SelectOptionSchema
    {
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Color Color { get; set; }
    }
}
