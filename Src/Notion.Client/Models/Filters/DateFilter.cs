using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class DateFilter : SinglePropertyFilter, IRollupSubPropertyFilter
    {
        public DateFilter(
            string propertyName,
            DateTime? equal = null,
            DateTime? before = null,
            DateTime? after = null,
            DateTime? onOrBefore = null,
            DateTime? onOrAfter = null,
            Dictionary<string, object> pastWeek = null,
            Dictionary<string, object> pastMonth = null,
            Dictionary<string, object> pastYear = null,
            Dictionary<string, object> nextWeek = null,
            Dictionary<string, object> nextMonth = null,
            Dictionary<string, object> nextYear = null,
            bool? isEmpty = null,
            bool? isNotEmpty = null)
        {
            Property = propertyName;

            Date = new Condition(
                equal,
                before,
                after,
                onOrBefore,
                onOrAfter,
                pastWeek,
                pastMonth,
                pastYear,
                nextWeek,
                nextMonth,
                nextYear,
                isEmpty,
                isNotEmpty
            );
        }

        [JsonProperty("date")]
        public Condition Date { get; set; }

        public class Condition
        {
            public Condition(
                DateTime? equal = null,
                DateTime? before = null,
                DateTime? after = null,
                DateTime? onOrBefore = null,
                DateTime? onOrAfter = null,
                Dictionary<string, object> pastWeek = null,
                Dictionary<string, object> pastMonth = null,
                Dictionary<string, object> pastYear = null,
                Dictionary<string, object> nextWeek = null,
                Dictionary<string, object> nextMonth = null,
                Dictionary<string, object> nextYear = null,
                bool? isEmpty = null,
                bool? isNotEmpty = null)
            {
                Equal = equal;
                Before = before;
                After = after;
                OnOrBefore = onOrBefore;
                OnOrAfter = onOrAfter;
                PastWeek = pastWeek;
                PastMonth = pastMonth;
                PastYear = pastYear;
                NextWeek = nextWeek;
                NextMonth = nextMonth;
                NextYear = nextYear;
                IsEmpty = isEmpty;
                IsNotEmpty = isNotEmpty;
            }

            [JsonProperty("equals")]
            [JsonConverter(typeof(IsoDateTimeConverter))]
            public DateTime? Equal { get; set; }

            [JsonProperty("before")]
            [JsonConverter(typeof(IsoDateTimeConverter))]
            public DateTime? Before { get; set; }

            [JsonProperty("after")]
            [JsonConverter(typeof(IsoDateTimeConverter))]
            public DateTime? After { get; set; }

            [JsonProperty("on_or_before")]
            [JsonConverter(typeof(IsoDateTimeConverter))]
            public DateTime? OnOrBefore { get; set; }

            [JsonProperty("on_or_after")]
            [JsonConverter(typeof(IsoDateTimeConverter))]
            public DateTime? OnOrAfter { get; set; }

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
            public bool? IsEmpty { get; set; }

            [JsonProperty("is_not_empty")]
            public bool? IsNotEmpty { get; set; }
        }
    }
}
