using Newtonsoft.Json;

namespace Notion.Client
{
    public class PDFBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.PDF;

        [JsonProperty("pdf")]
        public FileObject PDF { get; set; }
    }
}
