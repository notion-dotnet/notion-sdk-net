using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Result of creating meeting notes. The API may return only the block <see cref="Id" />;
    /// the remaining fields are filled when it returns the full block.
    /// </summary>
    public class CreateMeetingNotesResponse
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <summary>
        /// The ID of the meeting notes block.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// "meeting_notes" when the full block is returned.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("meeting_notes")]
        public MeetingNotesBlockData MeetingNotes { get; set; }

        [JsonProperty("created_time")]
        public DateTime? CreatedTime { get; set; }

        [JsonProperty("last_edited_time")]
        public DateTime? LastEditedTime { get; set; }

        [JsonProperty("has_children")]
        public bool? HasChildren { get; set; }

        [JsonProperty("in_trash")]
        public bool? InTrash { get; set; }
    }
}
