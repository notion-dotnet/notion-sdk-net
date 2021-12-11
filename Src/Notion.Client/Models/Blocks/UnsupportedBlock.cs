namespace Notion.Client
{
    public class UnsupportedBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.Unsupported;
    }
}
