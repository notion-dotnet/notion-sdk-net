using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class DateFilter : SinglePropertyFilter
    {
        [JsonProperty("equals")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Equal { get; set; }

        [JsonProperty("before")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Before { get; set; }

        [JsonProperty("after")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime After { get; set; }

        [JsonProperty("on_or_before")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime OnOrBefore { get; set; }

        [JsonProperty("on_or_after")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime OnOrAfter { get; set; }

        [JsonProperty("past_week")]
        public Dictionary<string, object> PastWeek { get; set; }

        [JsonProperty("past_month")]
        public Dictionary<string, object> PastMonth { get; set; }

        [JsonProperty("past_year")]
        public Dictionary<string, object> PastYear { get; set; }

        [JsonProperty("next_week")]
        public Dictionary<string, object> NextWeek { get; set; }

        [JsonProperty("next_month")]
        public Dictionary<string, object> NextMonth { get; set; }

        [JsonProperty("next_year")]
        public Dictionary<string, object> NextYear { get; set; }

        [JsonProperty("is_empty")]
        public bool IsEmpty => true;

        [JsonProperty("is_not_empty")]
        public bool IsNotEmpty => true;
    }
}