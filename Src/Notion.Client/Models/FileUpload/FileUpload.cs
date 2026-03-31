using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class FileUpload : IObject
    {
        public string Id { get; set; }
        public ObjectType Object => ObjectType.FileUpload;

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("created_by")]
        public PartialUser CreatedBy { get; set; }

        [JsonProperty("last_edited_time")]
        public DateTime LastEditedTime { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("expiry_time")]
        public DateTime? ExpiryTime { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("filename")]
        public string FileName { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("content_length")]
        public long? ContentLength { get; set; }

        [JsonProperty("upload_url")]
        public string UploadUrl { get; set; }

        [JsonProperty("complete_url")]
        public string CompleteUrl { get; set; }

        [JsonProperty("file_import_result")]
        public FileImportResult FileImportResult { get; set; }
    }
}
