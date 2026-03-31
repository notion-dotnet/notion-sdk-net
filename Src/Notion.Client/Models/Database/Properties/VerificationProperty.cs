using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class VerificationProperty : Property
    {
        public override PropertyType Type => PropertyType.Verification;

        [JsonProperty("verification")]
        public Dictionary<string, object> Verification { get; set; }
    }
}
