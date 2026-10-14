using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Creates a meeting notes block from an audio or video source.
    /// Use <see cref="MeetingNotesSource.FromFileUpload" /> together with <see cref="Parent" />, or
    /// <see cref="MeetingNotesSource.FromBlock" /> without a parent.
    /// </summary>
    public class CreateMeetingNotesRequest
    {
        /// <summary>
        /// Title for the meeting notes.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Language hint for transcription, see <see cref="MeetingNotesLanguage" />. Defaults to automatic detection.
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// Optional processing settings.
        /// </summary>
        [JsonProperty("options")]
        public CreateMeetingNotesOptions Options { get; set; }

        /// <summary>
        /// Audio or video source for the meeting notes.
        /// </summary>
        [JsonProperty("source")]
        public MeetingNotesSource Source { get; set; }

        /// <summary>
        /// Parent page for the new meeting notes. Required for file upload sources; not accepted for block sources.
        /// </summary>
        [JsonProperty("parent")]
        public PageParentRequest Parent { get; set; }
    }

    public class CreateMeetingNotesOptions
    {
        /// <summary>
        /// Whether to start summary generation after transcription.
        /// </summary>
        [JsonProperty("kickoff_summary")]
        public bool? KickoffSummary { get; set; }
    }

    public class MeetingNotesSource
    {
        /// <summary>
        /// "file_upload" or "block".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// ID of a completed file upload (for <c>file_upload</c> sources).
        /// </summary>
        [JsonProperty("file_upload_id")]
        public string FileUploadId { get; set; }

        /// <summary>
        /// ID of an existing audio, video or file block (for <c>block</c> sources).
        /// </summary>
        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        public static MeetingNotesSource FromFileUpload(string fileUploadId) =>
            new MeetingNotesSource { Type = "file_upload", FileUploadId = fileUploadId };

        public static MeetingNotesSource FromBlock(string blockId) =>
            new MeetingNotesSource { Type = "block", BlockId = blockId };
    }

    /// <summary>
    /// Language hints accepted for transcription.
    /// </summary>
    public static class MeetingNotesLanguage
    {
        public const string Auto = "auto";
        public const string English = "en";
        public const string ChineseSimplified = "zh-CN";
        public const string ChineseTraditional = "zh-TW";
        public const string Spanish = "es";
        public const string French = "fr";
        public const string German = "de";
        public const string Japanese = "ja";
        public const string Korean = "ko";
        public const string Portuguese = "pt";
        public const string Russian = "ru";
        public const string Thai = "th";
        public const string Vietnamese = "vi";
        public const string Indonesian = "id";
        public const string Danish = "da";
        public const string Finnish = "fi";
        public const string Norwegian = "no";
        public const string Dutch = "nl";
        public const string Italian = "it";
        public const string Swedish = "sv";
        public const string Arabic = "ar";
        public const string Hebrew = "he";
        public const string Polish = "pl";
    }
}
