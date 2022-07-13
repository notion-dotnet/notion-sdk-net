﻿using System.Collections.Generic;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ListPropertyItem : IPropertyItemObject
    {
        public string Object => "list";

        public virtual string Type { get; set; }

        public string Id { get; set; }

        public string NextURL { get; set; }

        [JsonProperty("results")]
        public IEnumerable<SimplePropertyItem> Results { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }

        [JsonProperty("property_item")]
        public SimplePropertyItem PropertyItem { get; set; }
    }
}
