using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class SinglePropertyRelation : RelationData
    {
        public override RelationType Type => RelationType.Single;

        [JsonProperty("single_property")]
        public Dictionary<string, object> SingleProperty { get; set; }
    }
}
