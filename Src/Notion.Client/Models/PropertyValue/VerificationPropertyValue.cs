using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Verification property value.
    /// </summary>
    public class VerificationPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Verification;

        /// <summary>
        ///     Object containing verification type-specific data.
        /// </summary>
        [JsonProperty("verification")]
        public Info Verification { get; set; }

        public class Info
        {
            /// <summary>
            ///     The state of verification. Possible values are "verified" and "unverified".
            /// </summary>
            [JsonProperty("state")]
            public string State { get; set; }

            /// <summary>
            ///     Describes the user who verified this page.
            /// </summary>
            [JsonProperty("verified_by")]
            public User VerifiedBy { get; set; }

            /// <summary>
            ///     Date verification property values contain a date property value.
            /// </summary>
            [JsonProperty("date")]
            public Date Date { get; set; }
        }
    }
}
