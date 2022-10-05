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
        ///     List of users.
        /// </summary>
        [JsonProperty("people")]
        public List<User> People { get; set; }
    }
}
