using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class RelationPropertySchema : IPropertySchema
    {
        [JsonProperty("relation")]
        public RelationInfo Relation { get; set; }

        public class RelationInfo
        {
            [JsonProperty("database_id")]
            public Guid DatabaseId { get; set; }

            [JsonProperty("synced_property_id")]
            public string SyncedPropertyId { get; set; }

            [JsonProperty("synced_property_name")]
            public string SyncedPropertyName { get; set; }
        }
    }
}
