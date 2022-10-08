using Newtonsoft.Json;

namespace Notion.Client
{
    public class FileUpdateBlock : UpdateBlock
    {
        [JsonProperty("file")]
        public IFileObjectInput File { get; set; }
    }
}
