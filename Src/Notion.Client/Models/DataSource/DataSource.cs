using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class DataSource : IObject, IObjectModificationData, IQueryDataSourceResponseObject, ISearchResponseObject
    {
        public string Id { get; set; }

        public ObjectType Object => ObjectType.DataSource;

        /// <summary>
        /// The title of the data source.
        /// </summary>
        [JsonProperty("title")]
        public IEnumerable<RichTextBase> Title { get; set; }

        /// <summary>
        /// A description of the data source.
        /// </summary>
        [JsonProperty("description")]
        public IEnumerable<RichTextBase> Description { get; set; }

        /// <summary>
        /// The parent of the data source.
        /// </summary>
        [JsonProperty("parent")]
        public IParentOfDatasource Parent { get; set; }

        /// <summary>
        /// The parent of the data source's containing database. This is typically a page, block,
        /// or workspace, but can be another database in the case of wikis.
        /// </summary>
        [JsonProperty("database_parent")]
        public IParentOfDatabase DatabaseParent { get; set; }

        /// <summary>
        /// Indicates whether the data source is inline within its parent database.
        /// </summary>
        [JsonProperty("is_inline")]
        public bool IsInline { get; set; }

        /// <summary>
        /// Indicates whether the data source is archived.
        /// </summary>
        [JsonProperty("archived")]
        public bool Archived { get; set; }

        /// <summary>
        /// Indicates whether the data source is in the trash.
        /// </summary>
        [JsonProperty("in_trash")]
        public bool InTrash { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime LastEditedTime { get; set; }

        public PartialUser CreatedBy { get; set; }

        public PartialUser LastEditedBy { get; set; }

        /// <summary>
        /// The properties schema of the data source.
        /// </summary>
        [JsonProperty("properties")]
        public IDictionary<string, DataSourcePropertyConfig> Properties { get; set; }

        /// <summary>
        /// The icon of the data source.
        /// </summary>
        [JsonProperty("icon")]
        public IPageIcon Icon { get; set; }

        /// <summary>
        /// The cover image of the data source.
        /// </summary>
        [JsonProperty("cover")]
        public IPageCover Cover { get; set; }

        /// <summary>
        /// The URL of the data source.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// The public page URL if the data source has been published to the web. Otherwise, null.
        /// </summary>
        [JsonProperty("public_url")]
        public string PublicUrl { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
