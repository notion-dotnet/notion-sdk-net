using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Title property value object.
    /// </summary>
    public class TitlePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Title;

        /// <summary>
        ///     An array of rich text objects
        /// </summary>
        [JsonProperty("title")]
        public List<RichTextBase> Title { get; set; }
    }
}
