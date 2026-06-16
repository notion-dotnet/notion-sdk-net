using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class MeetingNotesBlock : Block
    {
        public override BlockType Type => BlockType.MeetingNotes;

        [JsonProperty("meeting_notes")]
        public MeetingNotesBlockData MeetingNotes { get; set; }
    }

    public class MeetingNotesBlockData
    {
        [JsonProperty("title")]
        public IEnumerable<RichTextBase> Title { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("children")]
        public MeetingNotesChildrenData Children { get; set; }

        [JsonProperty("calendar_event")]
        public MeetingNotesCalendarEventData CalendarEvent { get; set; }

        [JsonProperty("recording")]
        public MeetingNotesRecordingData Recording { get; set; }
    }

    public class MeetingNotesChildrenData
    {
        [JsonProperty("summary_block_id")]
        public string SummaryBlockId { get; set; }

        [JsonProperty("notes_block_id")]
        public string NotesBlockId { get; set; }

        [JsonProperty("transcript_block_id")]
        public string TranscriptBlockId { get; set; }
    }

    public class MeetingNotesCalendarEventData
    {
        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        [JsonProperty("end_time")]
        public string EndTime { get; set; }

        [JsonProperty("attendees")]
        public IEnumerable<string> Attendees { get; set; }
    }

    public class MeetingNotesRecordingData
    {
        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        [JsonProperty("end_time")]
        public string EndTime { get; set; }
    }
}
