using Newtonsoft.Json;

namespace Notion.Client
{
    public class FileUploadPageCoverRequest : IPageCoverRequest
    {
        public string Type { get; set; } = PageCoverRequestTypes.FileUpload;

        [JsonProperty("file")]
        public Info File { get; set; }

        public class Info
        {
            /// <summary>
            /// The ID of a FileUpload object that has the status `uploaded`.
            /// </summary>
            [JsonProperty("id")]
            public string Id { get; set; }
        }
    }
}
