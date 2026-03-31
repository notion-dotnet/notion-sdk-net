using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class FileUploadIconRequest : IPageIconRequest
    {
        [JsonProperty("type")]
        public string Type => "file_upload";

        [JsonProperty("file_upload")]
        public FileUploadRequest FileUpload { get; set; }

        /// <summary>
        /// Additional data for future compatibility
        /// If you encounter properties that are not yet supported, please open an issue on GitHub.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }

        public class FileUploadRequest
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            /// <summary>
            /// Additional data for future compatibility
            /// If you encounter properties that are not yet supported, please open an issue on GitHub.
            /// </summary>
            [JsonExtensionData]
            public IDictionary<string, object> AdditionalData { get; set; }
        }
    }
}
