using Newtonsoft.Json;

namespace Notion.Client
{
    public class NumberProperty : Property
    {
        public override PropertyType Type => PropertyType.Number;

        [JsonProperty("number")]
        public Number Number { get; set; }
    }

    public class Number
    {
        [JsonProperty("format")]
        public string Format { get; set; }
    }
}
