using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IDatabasesCreateBodyParameters
    {
        /// <summary>
        /// Specifies the parent page or workspace where the database will be created.
        /// </summary>
        [JsonProperty("parent")]
        IParentOfDatabaseRequest Parent { get; set; }

        /// <summary>
        /// The title of the database.
        /// </summary>
        [JsonProperty("title")]
        List<RichTextBaseInput> Title { get; set; }

        /// <summary>
        /// The description of the database.
        /// </summary>
        [JsonProperty("description")]
        List<RichTextBaseInput> Description { get; set; }

        /// <summary>
        /// Indicates whether the database is inline.
        /// </summary>
        [JsonProperty("is_inline")]
        bool? IsInline { get; set; }

        /// <summary>
        /// Initial data source configuration for the database.
        /// </summary>
        [JsonProperty("initial_data_source")]
        InitialDataSourceRequest InitialDataSource { get; set; }

        /// <summary>
        /// Page icon for the database.
        /// </summary>
        [JsonProperty("icon")]
        public IPageIconRequest Icon { get; set; }

        /// <summary>
        /// Cover image for the database.
        /// </summary>
        [JsonProperty("cover")]
        public IPageCoverRequest Cover { get; set; }
    }
}
