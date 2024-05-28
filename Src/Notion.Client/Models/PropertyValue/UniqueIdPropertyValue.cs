using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Unique Id property value object.
    /// </summary>
    public class UniqueIdPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.UniqueId;

        /// <summary>
        ///     Unique Id property of database item
        /// </summary>
        [JsonProperty("unique_id")]
        public UniqueIdValue UniqueId { get; set; }
    }

    public class UniqueIdValue
    {
        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("number")]
        public double? Number { get; set; }
    }
}

