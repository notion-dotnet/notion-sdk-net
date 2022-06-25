using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Date property value object.
    /// </summary>
    public class DatePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Date;

        /// <summary>
        /// Date
        /// </summary>
        [JsonProperty("date", NullValueHandling = NullValueHandling.Include)]
        public Date? Date { get; set; }
    }

    /// <summary>
    /// Date value object.
    /// </summary>
    public class Date
    {
        /// <summary>
        /// Start date with optional time.
        /// </summary>
        [JsonProperty("start")]
        public DateTime? Start { get; set; }

        /// <summary>
        /// End date with optional time.
        /// </summary>
        [JsonProperty("end")]
        public DateTime? End { get; set; }
    }
}
