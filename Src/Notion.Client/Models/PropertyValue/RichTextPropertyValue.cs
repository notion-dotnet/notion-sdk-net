using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Rich Text property value object.
    /// </summary>
    public class RichTextPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.RichText;

        /// <summary>
        ///     List of rich text objects
        /// </summary>
        [JsonProperty("rich_text")]
        public List<RichTextBase> RichText { get; set; }
    }
}
