namespace Notion.Client
{
    public interface ITemplateChildrenBlockRequest : IBlockObjectRequest
    {
    }

    public interface ISyncedBlockChildrenRequest : IBlockObjectRequest
    {
    }

    public interface IColumnChildrenBlockRequest : ITemplateChildrenBlockRequest, ISyncedBlockChildrenRequest
    {
    }

    public interface INonColumnBlockRequest : IBlockObjectRequest
    {
    }
}
