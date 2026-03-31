using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class DualPropertyRelationInfo : RelationInfo
    {
        public override string Type => "dual_property";

        [JsonProperty("dual_property")]
        public Data DualProperty { get; set; }

        public class Data
        {
            [JsonProperty("synced_property_name")]
            public string SyncedPropertyName { get; set; }

            [JsonProperty("synced_property_id")]
            public string SyncedPropertyId { get; set; }

            [JsonExtensionData]
            public IDictionary<string, object> AdditionalData { get; set; }
        }
    }
}
