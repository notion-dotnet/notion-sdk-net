using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class Page : IObject
    {
        public ObjectType Object => ObjectType.Page;
        public string Id { get; set; }
        public Parent Parent { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("last_edited_time")]
        public DateTime LastEditedTime { get; set; }

        [JsonProperty("archived")]
        public bool IsArchived { get; set; }

        public IDictionary<string, PropertyValue> Properties { get; set; }
    }
}
