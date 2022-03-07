using Newtonsoft.Json;

namespace Notion.Client
{
    public class RelationProperty : Property
    {
        public override PropertyType Type => PropertyType.Relation;


        [JsonProperty("relation")]
        public Relation Relation { get; set; }
    }

    public class Relation
    {
        [JsonProperty("database_id")]
        public string DatabaseId { get; set; }

        [JsonProperty("synced_property_name")]
        public string SyncedPropertyName { get; set; }

        [JsonProperty("synced_property_id")]
        public string SyncedPropertyId { get; set; }
    }
}
