using System.Collections.Generic;

namespace Notion.Client
{
    public interface IDatabasesUpdateBodyParameters
    {
        [JsonProperty("properties")]
        Dictionary<string, IUpdatePropertySchema> Properties { get; set; }

        [JsonProperty("title")]
        List<RichTextBaseInput> Title { get; set; }

        [JsonProperty("icon")]
        IPageIcon Icon { get; set; }

        [JsonProperty("cover")]
        FileObject Cover { get; set; }

        [JsonProperty("description")]
        string Description { get; set; }
    }

    public class DatabasesUpdateParameters : IDatabasesUpdateBodyParameters
    {
        public Dictionary<string, IUpdatePropertySchema> Properties { get; set; }

        public List<RichTextBaseInput> Title { get; set; }

        public IPageIcon Icon { get; set; }

        public FileObject Cover { get; set; }

        public bool Archived { get; set; }

        public string Description { get; set; }
    }
}
