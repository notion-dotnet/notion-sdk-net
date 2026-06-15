namespace Notion.Client
{
    public class ListEmojisRequest : IListEmojisQueryParameters
    {
        public string StartCursor { get; set; }

        public int? PageSize { get; set; }
    }
}
