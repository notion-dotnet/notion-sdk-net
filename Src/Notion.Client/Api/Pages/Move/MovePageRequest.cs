namespace Notion.Client
{
    public class MovePageRequest : IMovePagePathParameters, IMovePageBodyParameters
    {
        public string PageId { get; set; }
        public MovePageParent Parent { get; set; }
    }
}
