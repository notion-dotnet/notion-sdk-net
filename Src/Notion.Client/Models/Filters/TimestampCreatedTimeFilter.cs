using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TimestampCreatedTimeFilter : Filter
    {
        public TimestampCreatedTimeFilter(
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
            CreatedTime = new DateFilter.Condition(
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

        [JsonProperty("timestamp")]
        public string Timestamp => "created_time";

        [JsonProperty("created_time")]
        public DateFilter.Condition CreatedTime { get; set; }
    }
}
