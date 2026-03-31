using Newtonsoft.Json;

namespace Notion.Client
{
    public class FileImportErrorResult : FileImportResult
    {
        public override string Type => "error";

        [JsonProperty("error")]
        public FileImportError Error { get; set; }
    }
}
