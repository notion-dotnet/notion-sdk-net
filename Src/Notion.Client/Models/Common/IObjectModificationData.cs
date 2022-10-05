using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IObjectModificationData
    {
        /// <summary>
        ///     Date and time when this object was created.
        /// </summary>
        [JsonProperty("created_time")]
        DateTime CreatedTime { get; set; }

        /// <summary>
        ///     Date and time when this object was updated.
        /// </summary>
        [JsonProperty("last_edited_time")]
        DateTime LastEditedTime { get; set; }

        /// <summary>
        ///     User who created the object.
        /// </summary>
        [JsonProperty("created_by")]
        PartialUser CreatedBy { get; set; }

        /// <summary>
        ///     User who last modified the object.
        /// </summary>
        [JsonProperty("last_edited_by")]
        PartialUser LastEditedBy { get; set; }
    }
}
