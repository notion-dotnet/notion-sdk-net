using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TimestampLastEditedTimeFilter : Filter
    {
        [JsonProperty("timestamp")]
        public string Timestamp = "last_modified_time";

        [JsonProperty("last_edited_time")]
        public DateFilter.Condition LastEditedTime { get; set; }

        public TimestampLastEditedTimeFilter(
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
            LastEditedTime = new DateFilter.Condition(
                equal: equal,
                before: before,
                after: after,
                onOrBefore: onOrBefore,
                onOrAfter: onOrAfter,
                pastWeek: pastWeek,
                pastMonth: pastMonth,
                pastYear: pastYear,
                nextWeek: nextWeek,
                nextMonth: nextMonth,
                nextYear: nextYear,
                isEmpty: isEmpty,
                isNotEmpty: isNotEmpty
            );
        }
    }
}
