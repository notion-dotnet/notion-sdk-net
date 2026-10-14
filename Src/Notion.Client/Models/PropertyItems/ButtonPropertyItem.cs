using Newtonsoft.Json;

namespace Notion.Client
{
    public class ButtonPropertyItem : SimplePropertyItem
    {
        public override string Type => "button";

        [JsonProperty("button")]
        public ButtonPropertyValue.ButtonValue Button { get; set; }
    }
}
