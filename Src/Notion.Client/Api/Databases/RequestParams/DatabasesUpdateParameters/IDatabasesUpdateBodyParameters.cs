using System.Collections.Generic;
using Newtonsoft.Json;

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

        [JsonProperty("archived")]
        bool Archived { get; set; }

        [JsonProperty("is_inline")]
        bool? IsInline { get; set; }

        [JsonProperty("description")]
        List<RichTextBaseInput> Description { get; set; }
    }
}
