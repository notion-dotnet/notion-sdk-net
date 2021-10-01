using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IDatabasesUpdateBodyParameters
    {
        Dictionary<string, IUpdatePropertySchema> Properties { get; set; }
        List<RichTextBaseInput> Title { get; set; }

        [JsonProperty("icon")]
        IPageIcon Icon { get; set; }

        [JsonProperty("cover")]
        FileObject Cover { get; set; }
    }

    public class DatabasesUpdateParameters : IDatabasesUpdateBodyParameters
    {
        public Dictionary<string, IUpdatePropertySchema> Properties { get; set; }
        public List<RichTextBaseInput> Title { get; set; }
        public IPageIcon Icon { get; set; }
        public FileObject Cover { get; set; }
    }
}
