namespace Notion.Client
{
    public interface ITemplateChildrendBlock : IBlock
    {
    }

    public interface ISyncedBlockChildren : IBlock
    {
    }

    public interface IColumnChildrenBlock : ITemplateChildrendBlock, ISyncedBlockChildren
    {
    }

    public interface INonColumnBlock : IBlock
    {
    }
}
