using Newtonsoft.Json;

namespace Notion.Client
{
    public class FileBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
    {
        [JsonProperty("file")]
        public FileObject File { get; set; }

        public override BlockType Type => BlockType.File;
    }
}
