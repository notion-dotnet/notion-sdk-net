using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Matches pages whose verification status is not the given status
    /// (<c>verified</c>, <c>expired</c> or <c>none</c>).
    /// </summary>
    public class VerificationPropertyDoesNotEqualFilter : SinglePropertyFilter
    {
        public VerificationPropertyDoesNotEqualFilter(
            string propertyName,
            VerificationStatus doesNotEqual)
        {
            Property = propertyName;
            Verification = new Condition(doesNotEqual);
        }

        [JsonProperty("verification")]
        public Condition Verification { get; set; }

        public class Condition
        {
            public Condition(VerificationStatus doesNotEqual)
            {
                DoesNotEqual = doesNotEqual;
            }

            [JsonProperty("does_not_equal")]
            public VerificationStatus DoesNotEqual { get; set; }
        }
    }
}
