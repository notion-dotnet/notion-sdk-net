using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class QueryMeetingNotesRequest
    {
        /// <summary>
        /// Filter criteria for the meeting notes query.
        /// </summary>
        [JsonProperty("filter")]
        public MeetingNotesCombinatorFilter Filter { get; set; }

        /// <summary>
        /// Sort criteria for the meeting notes query.
        /// </summary>
        [JsonProperty("sort")]
        public List<MeetingNotesSort> Sort { get; set; }

        /// <summary>
        /// Maximum number of results to return. Defaults to 100.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// Cursor for pagination — pass the value of <c>next_cursor</c> from the previous response.
        /// </summary>
        [JsonProperty("start_cursor")]
        public string StartCursor { get; set; }

        /// <summary>
        /// Number of items per page (max 100).
        /// </summary>
        [JsonProperty("page_size")]
        public int? PageSize { get; set; }
    }
}
