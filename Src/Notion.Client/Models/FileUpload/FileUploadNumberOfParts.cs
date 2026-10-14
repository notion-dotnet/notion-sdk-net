using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Progress of a multi-part file upload.
    /// </summary>
    public class FileUploadNumberOfParts
    {
        /// <summary>
        ///     Total number of parts expected for the upload.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        ///     Number of parts sent so far.
        /// </summary>
        [JsonProperty("sent")]
        public int Sent { get; set; }
    }
}
