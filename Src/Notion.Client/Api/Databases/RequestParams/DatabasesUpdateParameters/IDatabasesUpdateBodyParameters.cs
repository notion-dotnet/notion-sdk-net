using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IDatabasesUpdateBodyParameters
    {
        [JsonProperty("parent")]
        IParentOfDatabaseRequest Parent { get; set; }

        [JsonProperty("title")]
        List<RichTextBaseInput> Title { get; set; }

        [JsonProperty("icon")]
        IPageIconRequest Icon { get; set; }

        [JsonProperty("cover")]
        IPageCoverRequest Cover { get; set; }

        [JsonProperty("in_trash")]
        bool? InTrash { get; set; }

        [JsonProperty("is_inline")]
        bool? IsInline { get; set; }

        [JsonProperty("description")]
        List<RichTextBaseInput> Description { get; set; }

        [JsonProperty("is_locked")]
        bool? IsLocked { get; set; }
    }
}
