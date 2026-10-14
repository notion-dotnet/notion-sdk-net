using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// A file attached to a comment (response).
    /// </summary>
    public class CommentAttachment
    {
        /// <summary>
        /// One of: audio, image, pdf, productivity, video.
        /// </summary>
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("file")]
        public CommentAttachmentFile File { get; set; }
    }

    public class CommentAttachmentFile
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("expiry_time")]
        public DateTime ExpiryTime { get; set; }
    }

    /// <summary>
    /// A file to attach to a comment (request). The file must be a file upload with status <c>uploaded</c>.
    /// A comment can have at most 3 attachments.
    /// </summary>
    public class CommentAttachmentRequest
    {
        public CommentAttachmentRequest()
        {
        }

        public CommentAttachmentRequest(string fileUploadId)
        {
            FileUploadId = fileUploadId;
        }

        [JsonProperty("type")]
        public string Type => "file_upload";

        [JsonProperty("file_upload_id")]
        public string FileUploadId { get; set; }
    }

    /// <summary>
    /// Display name of a comment. Use <see cref="Integration" />, <see cref="User" /> or
    /// <see cref="CustomName" /> to build one for a request; responses fill <see cref="ResolvedName" />.
    /// </summary>
    public class CommentDisplayName
    {
        /// <summary>
        /// One of: custom, user, integration.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Only for <c>custom</c> display names (request).
        /// </summary>
        [JsonProperty("custom")]
        public CustomInfo Custom { get; set; }

        /// <summary>
        /// The name that was resolved for display (response).
        /// </summary>
        [JsonProperty("resolved_name")]
        public string ResolvedName { get; set; }

        public static CommentDisplayName Integration() => new CommentDisplayName { Type = "integration" };

        public static CommentDisplayName User() => new CommentDisplayName { Type = "user" };

        public static CommentDisplayName CustomName(string name) =>
            new CommentDisplayName { Type = "custom", Custom = new CustomInfo { Name = name } };

        public class CustomInfo
        {
            [JsonProperty("name")]
            public string Name { get; set; }
        }
    }
}
