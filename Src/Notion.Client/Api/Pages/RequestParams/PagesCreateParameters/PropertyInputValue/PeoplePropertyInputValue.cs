using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// People property value object.
    /// </summary>
    public class PeoplePropertyInputValue : PropertyInputValue
    {
        /// <summary>
        /// List of users.
        /// </summary>
        [JsonProperty("people")]
        public List<User> People { get; set; }
    }
}
