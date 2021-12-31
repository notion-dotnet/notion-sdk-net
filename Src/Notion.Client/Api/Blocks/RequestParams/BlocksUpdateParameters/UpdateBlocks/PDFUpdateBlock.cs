using Newtonsoft.Json;

namespace Notion.Client
{
    public class PDFUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("pdf")]
        public IFileObjectInput PDF { get; set; }
    }
}
