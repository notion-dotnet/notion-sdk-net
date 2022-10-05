using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Multi-select property value object.
    /// </summary>
    public class MultiSelectPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.MultiSelect;

        /// <summary>
        ///     An array of multi-select option values.
        /// </summary>
        [JsonProperty("multi_select")]
        public List<SelectOption> MultiSelect { get; set; }
    }
}
