using Newtonsoft.Json;

namespace Notion.Client
{
    public class ButtonPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Button;

        [JsonProperty("button")]
        public ButtonValue Button { get; set; }

        public class ButtonValue { }
    }
}
