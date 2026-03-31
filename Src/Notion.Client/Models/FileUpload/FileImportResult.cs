using System;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FileImportSuccessResult), "success")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FileImportErrorResult), "error")]
    [JsonSubtypes.FallBackSubTypeAttribute(typeof(FileImportResult))]
    public abstract class FileImportResult
    {
        [JsonProperty("type")]
        public virtual string Type { get; set; }

        [JsonProperty("imported_time")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime ImportedTime { get; set; }
    }
}
