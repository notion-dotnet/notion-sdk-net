﻿using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(UploadedFileWithName), "file")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ExternalFileWithName), "external")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FileUploadWithName), "file_upload")]
    public abstract class FileObjectWithName
    {
        [JsonProperty("type")]
        public virtual string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
