using Newtonsoft.Json;

namespace Notion.Client
{
    public class PDFBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("pdf")]
        public FileObject PDF { get; set; }

        public override BlockType Type => BlockType.PDF;
    }
}
