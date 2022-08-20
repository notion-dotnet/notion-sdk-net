using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class DatabasesCreateParameters : IDatabasesCreateBodyParameters, IDatabasesCreateQueryParameters
    {
        [JsonProperty("parent")]
        public ParentPageInput Parent { get; set; }

        [JsonProperty("properties")]
        public Dictionary<string, IPropertySchema> Properties { get; set; }

        [JsonProperty("title")]
        public List<RichTextBaseInput> Title { get; set; }

        [JsonProperty("icon")]
        public IPageIcon Icon { get; set; }

        [JsonProperty("cover")]
        public FileObject Cover { get; set; }

        public bool? IsInline { get; set; }
    }
}
