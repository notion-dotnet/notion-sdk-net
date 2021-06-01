using Newtonsoft.Json;

namespace Notion.Client
{
    public class CheckboxFilter : SinglePropertyFilter
    {
        [JsonProperty("equals")]
        public bool Equal { get; set; }

        [JsonProperty("does_not_equal")]
        public bool DoesNotEqual { get; set; }
    }
}