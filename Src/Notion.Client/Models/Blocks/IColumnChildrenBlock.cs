namespace Notion.Client
{
    public interface ITemplateChildrendBlock : IBlock
    {
    }

    public interface IColumnChildrenBlock : IBlock, ITemplateChildrendBlock
    {
    }

    public interface INonColumnBlock : IBlock
    {
    }
}
