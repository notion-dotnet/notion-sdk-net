namespace Notion.Client
{
    public class WorkspaceParent : IPageParent, IDatabaseParent
    {
        public ParentType Type { get; set; }
    }
}
