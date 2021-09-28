using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class RelationPropertySchema : IPropertySchema
    {
        [JsonProperty("database_id")]
        public Guid DatabaseId { get; set; }
    }
}
