using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ListFileUploadsResponse : PaginatedList<FileUpload>
    {
        [JsonProperty("file_uploads")]
        public Dictionary<string, object> FileUploads { get; set; }
    }
}
