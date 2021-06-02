namespace Notion.Client
{
    public class UnsupportedBlock : Block
    {
        public override BlockType Type => BlockType.Unsupported;
    }
}