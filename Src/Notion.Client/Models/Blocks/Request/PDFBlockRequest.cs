using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class PDFBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
    {
        [JsonProperty("pdf")]
        public FileObject PDF { get; set; }

        public override BlockType Type => BlockType.PDF;
    }
}
