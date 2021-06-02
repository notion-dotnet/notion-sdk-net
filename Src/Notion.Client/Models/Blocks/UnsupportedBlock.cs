namespace Notion.Client
{
    public class UnsupportedBlock : BlockBase
    {
        public override BlockType Type => BlockType.Unsupported;
    }
}