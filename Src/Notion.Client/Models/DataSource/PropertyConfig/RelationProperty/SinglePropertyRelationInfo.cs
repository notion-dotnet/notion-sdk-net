using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class SinglePropertyRelationInfo : RelationInfo
    {
        public override string Type => "single_property";

        [JsonProperty("single_property")]
        public Dictionary<string, object> SingleProperty { get; set; }
    }
}
