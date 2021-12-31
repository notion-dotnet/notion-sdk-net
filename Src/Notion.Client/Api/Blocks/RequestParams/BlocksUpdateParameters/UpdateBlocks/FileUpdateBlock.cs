using Newtonsoft.Json;

namespace Notion.Client
{
    public class FileUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("file")]
        public IFileObjectInput File { get; set; }
    }
}
