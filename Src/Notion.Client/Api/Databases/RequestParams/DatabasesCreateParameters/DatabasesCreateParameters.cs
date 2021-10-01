using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class DatabasesCreateParameters : IDatabasesCreateBodyParameters, IDatabasesCreateQueryParameters
    {
        public ParentPageInput Parent { get; set; }
        public Dictionary<string, IPropertySchema> Properties { get; set; }
        public List<RichTextBaseInput> Title { get; set; }

        [JsonProperty("icon")]
        public IPageIcon Icon { get; set; }

        [JsonProperty("cover")]
        public FileObject Cover { get; set; }
    }
}
