using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Created by property value object
    /// </summary>
    public class CreatedByPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.CreatedBy;

        /// <summary>
        ///     Describes the user who created this page.
        /// </summary>
        [JsonProperty("created_by")]
        public User CreatedBy { get; set; }
    }
}
