using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IObjectModificationData
    {
        /// <summary>
        /// Date and time when this object was created.
        /// </summary>
        [JsonProperty("created_time")]
        DateTime CreatedTime { get; set; }

        /// <summary>
        /// Date and time when this object was updated.
        /// </summary>
        [JsonProperty("last_edited_time")]
        DateTime LastEditedTime { get; set; }
    }
}
