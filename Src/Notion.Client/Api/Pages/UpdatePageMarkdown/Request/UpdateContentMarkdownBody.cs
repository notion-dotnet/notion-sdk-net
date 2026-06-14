using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Updates specific content in the page using search-and-replace operations.
    /// </summary>
    public class UpdateContentMarkdownBody : UpdatePageMarkdownBody
    {
        public override string Type => "update_content";

        [JsonProperty("update_content")]
        public UpdateContentData UpdateContent { get; set; }
    }

    public class UpdateContentData
    {
        /// <summary>
        /// An array of search-and-replace operations to apply.
        /// </summary>
        [JsonProperty("content_updates")]
        public IList<ContentUpdate> ContentUpdates { get; set; }

        /// <summary>
        /// Set to <c>true</c> to allow the operation to delete child pages or databases.
        /// Defaults to <c>false</c>.
        /// </summary>
        [JsonProperty("allow_deleting_content")]
        public bool? AllowDeletingContent { get; set; }
    }

    public class ContentUpdate
    {
        /// <summary>
        /// The existing content string to find and replace. Must exactly match the page content.
        /// </summary>
        [JsonProperty("old_str")]
        public string OldStr { get; set; }

        /// <summary>
        /// The new content string to replace <see cref="OldStr"/> with.
        /// </summary>
        [JsonProperty("new_str")]
        public string NewStr { get; set; }

        /// <summary>
        /// If <c>true</c>, replaces all occurrences of <see cref="OldStr"/>.
        /// If <c>false</c> (default), the operation fails if there are multiple matches.
        /// </summary>
        [JsonProperty("replace_all_matches")]
        public bool? ReplaceAllMatches { get; set; }
    }
}
