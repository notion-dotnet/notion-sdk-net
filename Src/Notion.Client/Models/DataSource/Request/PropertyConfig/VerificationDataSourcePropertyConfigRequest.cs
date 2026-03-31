using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class VerificationDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "verification";

        [JsonProperty("verification")]
        public IDictionary<string, object> Verification { get; set; }
    }
}