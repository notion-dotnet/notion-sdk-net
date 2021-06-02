using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Notion.Client
{
    public class Database
    {
        public string Object => "database";
        public string Id { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("last_edited_time")]
        public DateTime LastEditedTime { get; set; }

        public List<RichTextBase> Title { get; set; }

        public Dictionary<string, Property> Properties { get; set; }
    }
}