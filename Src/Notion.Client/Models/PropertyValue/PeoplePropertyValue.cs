using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     People property value object.
    /// </summary>
    public class PeoplePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.People;

        /// <summary>
        ///     List of users and groups. Each entry is a <see cref="User"/> or a <see cref="Group"/>.
        /// </summary>
        [JsonProperty("people")]
        public List<IPeopleValue> People { get; set; }
    }
}
