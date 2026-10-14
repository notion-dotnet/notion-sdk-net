using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Limits and restrictions that apply to a bot's workspace.
    /// </summary>
    public class WorkspaceLimits
    {
        /// <summary>
        ///     The maximum allowable size of a file upload, in bytes.
        /// </summary>
        [JsonProperty("max_file_upload_size_in_bytes")]
        public long MaxFileUploadSizeInBytes { get; set; }
    }
}
