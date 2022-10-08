using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class PDFBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("pdf")]
        public FileObject PDF { get; set; }

        public override BlockType Type => BlockType.PDF;
    }
}
