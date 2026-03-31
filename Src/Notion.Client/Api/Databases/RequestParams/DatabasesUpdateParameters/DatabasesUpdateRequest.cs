using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class DatabasesUpdateRequest : IDatabasesUpdatePathParameters, IDatabasesUpdateBodyParameters
    {
        public string DatabaseId { get; set; }

        public List<RichTextBaseInput> Title { get; set; }

        public IPageIconRequest Icon { get; set; }

        public IPageCoverRequest Cover { get; set; }

        public bool? InTrash { get; set; }

        public bool? IsInline { get; set; }

        public List<RichTextBaseInput> Description { get; set; }

        public bool? IsLocked { get; set; }

        public IParentOfDatabaseRequest Parent { get; set; }
    }

    public interface IDatabasesUpdatePathParameters
    {
        /// <summary>
        /// The ID of the database to update.
        /// </summary>
        [JsonIgnore]
        [JsonProperty("database_id")]
        string DatabaseId { get; set; }
    }
}
