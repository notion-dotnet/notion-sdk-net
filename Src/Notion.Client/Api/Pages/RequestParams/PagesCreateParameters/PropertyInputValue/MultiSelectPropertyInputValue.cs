using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Multi-select property value object.
    /// </summary>
    public class MultiSelectPropertyInputValue : PropertyInputValue
    {
        /// <summary>
        /// An array of multi-select option values.
        /// </summary>
        [JsonProperty("multi_select")]
        public List<SelectOption> MultiSelect { get; set; }
    }
}
