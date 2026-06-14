using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IPagesCreateBodyParameters
    {
        [JsonProperty("parent")]
        IParentOfPageRequest Parent { get; set; }

        [JsonProperty("properties")]
        IDictionary<string, PropertyValue> Properties { get; set; }

        [JsonProperty("children")]
        IList<IBlock> Children { get; set; }

        [JsonProperty("icon")]
        IPageIconRequest Icon { get; set; }

        [JsonProperty("cover")]
        IPageCoverRequest Cover { get; set; }

        [JsonProperty("markdown")]
        string Markdown { get; set; }

        /// <summary>
        /// Template to apply when creating the page.
        /// Use <see cref="NonePageTemplate"/>, <see cref="DefaultPageTemplate"/>, or <see cref="TemplateIdPageTemplate"/>.
        /// Mutually exclusive with <see cref="Children"/> and <see cref="Markdown"/>.
        /// </summary>
        [JsonProperty("template")]
        PageTemplate Template { get; set; }

        /// <summary>
        /// Controls where the new page is placed within its parent.
        /// Use <see cref="AfterBlockPagePosition"/>, <see cref="PageStartPosition"/>, or <see cref="PageEndPosition"/>.
        /// </summary>
        [JsonProperty("position")]
        PagePosition Position { get; set; }
    }
}
