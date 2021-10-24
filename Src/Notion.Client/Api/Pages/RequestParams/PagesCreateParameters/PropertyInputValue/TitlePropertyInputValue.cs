using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Title property value object.
    /// </summary>
    public class TitlePropertyInputValue : PropertyInputValue
    {
        /// <summary>
        /// An array of rich text objects
        /// </summary>
        [JsonProperty("title")]
        public List<RichTextBase> Title { get; set; }
    }
}
