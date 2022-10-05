namespace Notion.Client
{
    public class WorkspaceParent : IPageParent, IDatabaseParent, IBlockParent
    {
        /// <summary>
        ///     Always "workspace".
        /// </summary>
        public ParentType Type { get; set; }
    }
}
