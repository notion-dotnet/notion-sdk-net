using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class PagesUpdateParameters : IPagesUpdateBodyParameters
    {
        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("properties")]
        public IDictionary<string, PropertyValue> Properties { get; set; }

        [JsonProperty("icon")]
        public IPageIcon Icon { get; set; }

        [JsonProperty("cover")]
        public FileObject Cover { get; set; }
    }
}
