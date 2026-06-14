using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IPagesUpdateBodyParameters
    {
        [JsonProperty("icon")]
        IPageIconRequest Icon { get; set; }

        [JsonProperty("cover")]
        IPageCoverRequest Cover { get; set; }

        [JsonProperty("in_trash")]
        bool InTrash { get; set; }

        [JsonProperty("properties")]
        IDictionary<string, PropertyValue> Properties { get; set; }

        /// <summary>
        /// Template to apply to the page. Use <see cref="DefaultPageTemplate"/> or <see cref="TemplateIdPageTemplate"/>.
        /// </summary>
        [JsonProperty("template")]
        PageTemplate Template { get; set; }

        /// <summary>
        /// When <c>true</c>, erases all existing content from the page before applying the template (if any).
        /// </summary>
        [JsonProperty("erase_content")]
        bool? EraseContent { get; set; }

        /// <summary>
        /// Whether the page should be locked from editing in the Notion app UI.
        /// If not provided, the locked state will not be updated.
        /// </summary>
        [JsonProperty("is_locked")]
        bool? IsLocked { get; set; }
    }
}
