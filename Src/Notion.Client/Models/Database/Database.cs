using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class Database : IObject
    {
        public ObjectType Object => ObjectType.Database;

        public string Id { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("last_edited_time")]
        public DateTime LastEditedTime { get; set; }

        public List<RichTextBase> Title { get; set; }

        public Dictionary<string, Property> Properties { get; set; }

        public IDatabaseParent Parent { get; set; }

        [JsonProperty("icon")]
        public IPageIcon Icon { get; set; }

        [JsonProperty("cover")]
        public FileObject Cover { get; set; }
    }
}
