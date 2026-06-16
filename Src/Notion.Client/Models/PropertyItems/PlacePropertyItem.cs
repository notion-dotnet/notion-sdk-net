using Newtonsoft.Json;

namespace Notion.Client
{
    public class PlacePropertyItem : SimplePropertyItem
    {
        public override string Type => "place";

        [JsonProperty("place")]
        public PlacePropertyValue.PlaceInfo Place { get; set; }
    }
}
