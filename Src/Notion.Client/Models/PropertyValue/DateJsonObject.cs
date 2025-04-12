using Newtonsoft.Json;

namespace Notion.Client
{
    internal class DateJsonObject
    {
        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }
    }
}
