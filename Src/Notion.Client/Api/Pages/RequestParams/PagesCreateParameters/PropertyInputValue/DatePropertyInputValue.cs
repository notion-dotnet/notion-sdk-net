using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Date property value object.
    /// </summary>
    public class DatePropertyInputValue : PropertyInputValue
    {
        /// <summary>
        /// Date
        /// </summary>
        [JsonProperty("date")]
        public DateInfo Date { get; set; }

        /// <summary>
        /// Date value object.
        /// </summary>
        public class DateInfo
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
}
