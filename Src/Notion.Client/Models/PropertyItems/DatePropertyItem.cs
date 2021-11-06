using Newtonsoft.Json;

namespace Notion.Client
{
    public class DatePropertyItem : SimplePropertyItem
    {
        public override string Type => "date";

        [JsonProperty("date")]
        public Date Date { get; set; }
    }
}
