using Newtonsoft.Json;

namespace Notion.Client
{
    public class DualPropertyRelation : RelationData
    {
        public override RelationType Type => RelationType.Dual;

        [JsonProperty("dual_property")]
        public Data DualProperty { get; set; }

        public class Data
        {
            [JsonProperty("synced_property_name")]
            public string SyncedPropertyName { get; set; }

            [JsonProperty("synced_property_id")]
            public string SyncedPropertyId { get; set; }
        }
    }
}
