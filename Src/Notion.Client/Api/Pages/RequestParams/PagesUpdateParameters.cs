using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class PagesUpdateParameters : IPagesUpdateBodyParameters
    {
        [JsonProperty("icon")]
        public IPageIconRequest Icon { get; set; }

        [JsonProperty("cover")]
        public IPageCoverRequest Cover { get; set; }

        [JsonProperty("in_trash")]
        public bool? InTrash { get; set; }

        [JsonProperty("properties")]
        public IDictionary<string, PropertyValue> Properties { get; set; }

        /// <summary>
        /// Template to apply to the page. Use <see cref="DefaultPageTemplate"/> or <see cref="TemplateIdPageTemplate"/>.
        /// When combined with <see cref="EraseContent"/>, the template content replaces existing content.
        /// </summary>
        [JsonProperty("template")]
        public PageTemplate Template { get; set; }

        /// <summary>
        /// When <c>true</c>, erases all existing content from the page before applying the template (if any).
        /// </summary>
        [JsonProperty("erase_content")]
        public bool? EraseContent { get; set; }

        /// <summary>
        /// Whether the page should be locked from editing in the Notion app UI.
        /// If not provided, the locked state will not be updated.
        /// </summary>
        [JsonProperty("is_locked")]
        public bool? IsLocked { get; set; }

        /// <summary>
        /// Whether the page should be archived. If not provided, the archived state will not be updated.
        /// </summary>
        [JsonProperty("is_archived")]
        public bool? IsArchived { get; set; }

        /// <summary>
        /// Limits the returned page properties to the given property ids (sent as the
        /// <c>filter_properties</c> query parameter, not in the body).
        /// </summary>
        [JsonIgnore]
        public IEnumerable<string> FilterProperties { get; set; }
    }
}
