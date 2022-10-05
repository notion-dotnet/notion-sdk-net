using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Date property value object.
    /// </summary>
    public class DatePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Date;

        /// <summary>
        ///     Date
        /// </summary>
        [JsonProperty("date", NullValueHandling = NullValueHandling.Include)]
        public Date Date { get; set; }
    }

    /// <summary>
    ///     Date value object.
    /// </summary>
    public class Date
    {
        /// <summary>
        ///     Start date with optional time.
        /// </summary>
        [JsonProperty("start")]
        public DateTime? Start { get; set; }

        /// <summary>
        ///     End date with optional time.
        /// </summary>
        [JsonProperty("end")]
        public DateTime? End { get; set; }

        /// <summary>
        ///     Optional time zone information for start and end. Possible values are extracted from the IANA database and they are
        ///     based on the time zones from Moment.js.
        /// </summary>
        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }
    }
}
