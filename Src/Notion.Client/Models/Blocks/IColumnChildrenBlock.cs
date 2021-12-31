namespace Notion.Client
{
    public interface ITemplateChildrendBlock : IBlock
    {
    }

    public interface ISyncedBlockChildren : IBlock
    {
    }

    public interface IColumnChildrenBlock : IBlock, ITemplateChildrendBlock, ISyncedBlockChildren
    {
    }

    public interface INonColumnBlock : IBlock
    {
    }
}
