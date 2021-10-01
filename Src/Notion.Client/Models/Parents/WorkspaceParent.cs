namespace Notion.Client
{
    public class WorkspaceParent : IPageParent, IDatabaseParent
    {
        /// <summary>
        /// Always "workspace".
        /// </summary>
        public ParentType Type { get; set; }
    }
}
