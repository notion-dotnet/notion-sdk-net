using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TranscriptionBlock : Block
    {
        public override BlockType Type => BlockType.Transcription;

        [JsonProperty("transcription")]
        public TranscriptionBlockResponse Transcription { get; set; }
    }

    public class TranscriptionBlockResponse
    {
        [JsonProperty("title")]
        public IEnumerable<RichTextBase> Title { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("children")]
        public TranscriptionChildrenResponse Children { get; set; }

        [JsonProperty("calendar_event")]
        public TranscriptionCalendarEventResponse CalendarEvent { get; set; }

        [JsonProperty("recording")]
        public TranscriptionRecordingResponse Recording { get; set; }
    }

    public class TranscriptionChildrenResponse
    {
        [JsonProperty("summary_block_id")]
        public string SummaryBlockId { get; set; }

        [JsonProperty("notes_block_id")]
        public string NotesBlockId { get; set; }

        [JsonProperty("transcript_block_id")]
        public string TranscriptBlockId { get; set; }
    }

    public class TranscriptionCalendarEventResponse
    {
        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        [JsonProperty("end_time")]
        public string EndTime { get; set; }

        [JsonProperty("attendees")]
        public IEnumerable<string> Attendees { get; set; }
    }

    public class TranscriptionRecordingResponse
    {
        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        [JsonProperty("end_time")]
        public string EndTime { get; set; }
    }
}