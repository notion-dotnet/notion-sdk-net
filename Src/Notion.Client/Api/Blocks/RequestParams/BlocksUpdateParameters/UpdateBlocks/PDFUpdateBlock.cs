using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class PDFUpdateBlock : UpdateBlock
    {
        [JsonProperty("pdf")]
        public IFileObjectInput PDF { get; set; }
    }
}
