using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class FileImportSuccessResult : FileImportResult
    {
        public override string Type => "success";

        [JsonProperty("success")]
        public Dictionary<string, object> Success { get; set; }
    }
}
