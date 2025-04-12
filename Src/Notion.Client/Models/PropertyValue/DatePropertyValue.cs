using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
    [JsonConverter(typeof(DateCustomConverter))]
    public class Date
    {
        /// <summary>
        ///     Start date with optional time.
        /// </summary>
        [JsonProperty("start")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTimeOffset? Start { get; set; }

        /// <summary>
        ///     End date with optional time.
        /// </summary>
        [JsonProperty("end")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTimeOffset? End { get; set; }

        /// <summary>
        ///     Optional time zone information for start and end. Possible values are extracted from the IANA database and they are
        ///     based on the time zones from Moment.js.
        /// </summary>
        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        /// <summary>
        ///     Whether to include time
        /// </summary>
        public bool IncludeTime { get; set; } = true;
    }
}
