namespace Notion.Client
{
    public interface ITemplateChildrenBlock : IBlock
    {
    }

    public interface ISyncedBlockChildren : IBlock
    {
    }

    public interface IColumnChildrenBlock : ITemplateChildrenBlock, ISyncedBlockChildren
    {
    }

    public interface INonColumnBlock : IBlock
    {
    }
}
