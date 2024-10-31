using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class Page : IObject, IObjectModificationData, IWikiDatabase
    {
        /// <summary>
        ///     The parent of this page. Can be a database, page, or workspace.
        /// </summary>
        [JsonProperty("parent")]
        public IPageParent Parent { get; set; }

        /// <summary>
        ///     Indicates whether the page is currently in the trash.
        /// </summary>
        [JsonProperty("in_trash")]
        public bool InTrash { get; set; }

        /// <summary>
        ///     Property values of this page.
        /// </summary>
        [JsonProperty("properties")]
        public IDictionary<string, PropertyValue> Properties { get; set; }

        /// <summary>
        ///     The URL of the Notion page.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        ///     Page icon.
        /// </summary>
        [JsonProperty("icon")]
        public IPageIcon Icon { get; set; }

        /// <summary>
        ///     Page cover image.
        /// </summary>
        [JsonProperty("cover")]
        public FileObject Cover { get; set; }

        /// <summary>
        ///     Object type
        /// </summary>
        public ObjectType Object => ObjectType.Page;

        /// <summary>
        ///     Unique identifier of the page.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Date and time when this page was created.
        /// </summary>
        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        ///     Date and time when this page was updated.
        /// </summary>
        [JsonProperty("last_edited_time")]
        public DateTime LastEditedTime { get; set; }

        public PartialUser CreatedBy { get; set; }

        public PartialUser LastEditedBy { get; set; }

        /// <summary>
        ///     The public page URL if the page has been published to the web. Otherwise, null.
        /// </summary>
        [JsonProperty("public_url")]
        public string PublicUrl { get; set; }
    }
}
