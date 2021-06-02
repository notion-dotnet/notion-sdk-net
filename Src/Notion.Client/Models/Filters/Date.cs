using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class DateFilter : SinglePropertyFilter
    {
        public Condition Date { get; set; }

        public class Condition
        {
            [JsonProperty("equals")]
            [JsonConverter(typeof(IsoDateTimeConverter))]
            public Nullable<DateTime> Equal { get; set; }

            [JsonProperty("before")]
            [JsonConverter(typeof(IsoDateTimeConverter))]
            public Nullable<DateTime> Before { get; set; }

            [JsonProperty("after")]
            [JsonConverter(typeof(IsoDateTimeConverter))]
            public Nullable<DateTime> After { get; set; }

            [JsonProperty("on_or_before")]
            [JsonConverter(typeof(IsoDateTimeConverter))]
            public Nullable<DateTime> OnOrBefore { get; set; }

            [JsonProperty("on_or_after")]
            [JsonConverter(typeof(IsoDateTimeConverter))]
            public Nullable<DateTime> OnOrAfter { get; set; }

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
            public Nullable<bool> IsEmpty { get; set; }

            [JsonProperty("is_not_empty")]
            public Nullable<bool> IsNotEmpty { get; set; }
        }
    }
}