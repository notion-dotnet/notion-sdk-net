using Newtonsoft.Json;

namespace Notion.Client
{
    public class VerificationPropertyItem : SimplePropertyItem
    {
        public override string Type => "verification";

        /// <summary>
        ///     The verification state; <c>null</c> when the page has never been verified.
        /// </summary>
        [JsonProperty("verification")]
        public VerificationPropertyValue.Info Verification { get; set; }
    }
}
