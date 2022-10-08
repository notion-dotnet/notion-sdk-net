using Newtonsoft.Json;

namespace Notion.Client
{
    public class FileBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("file")]
        public FileObject File { get; set; }

        public override BlockType Type => BlockType.File;
    }
}
