using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class View : IObject
    {
        public string Id { get; set; }

        public ObjectType Object => ObjectType.View;

        [JsonProperty("type")]
        public ViewType Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("data_source_id")]
        public string DataSourceId { get; set; }

        [JsonProperty("parent")]
        public DatabaseParent Parent { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("last_edited_time")]
        public DateTime LastEditedTime { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created_by")]
        public PartialUser CreatedBy { get; set; }

        [JsonProperty("last_edited_by")]
        public PartialUser LastEditedBy { get; set; }

        [JsonProperty("filter")]
        public object Filter { get; set; }

        [JsonProperty("sorts")]
        public IEnumerable<ViewSort> Sorts { get; set; }

        [JsonProperty("configuration")]
        public ViewConfiguration Configuration { get; set; }
    }
}
