using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class Database : IObject, IObjectModificationData
    {
        public ObjectType Object => ObjectType.Database;

        public string Id { get; set; }

        /// <summary>
        /// The title of the database.
        /// </summary>
        [JsonProperty("title")]
        public List<RichTextBase> Title { get; set; }

        /// <summary>
        /// The description of the database.
        /// </summary>
        [JsonProperty("description")]
        public IEnumerable<RichTextBase> Description { get; set; }

        /// <summary>
        /// Parent of the database.
        /// </summary>
        [JsonProperty("parent")]
        public IParentOfDatabase Parent { get; set; }

        [JsonProperty("is_inline")]
        public bool IsInline { get; set; }

        [JsonProperty("in_trash")]
        public bool InTrash { get; set; }

        [JsonProperty("is_locked")]
        public bool IsLocked { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("last_edited_time")]
        public DateTime LastEditedTime { get; set; }

        public PartialUser CreatedBy { get; set; }

        public PartialUser LastEditedBy { get; set; }

        /// <summary>
        /// The data sources associated with the database.
        /// </summary>
        [JsonProperty("data_sources")]
        public IEnumerable<DataSourceReferenceResponse> DataSources { get; set; }

        [JsonProperty("icon")]
        public IPageIcon Icon { get; set; }

        /// <summary>
        /// The cover image of the database.
        /// </summary>
        [JsonProperty("cover")]
        public IPageCover Cover { get; set; }

        /// <summary>
        ///     The URL of the Notion database.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// The public page URL if the page has been published to the web. Otherwise, null.
        /// </summary>
        [JsonProperty("public_url")]
        public string PublicUrl { get; set; }
    }
}
