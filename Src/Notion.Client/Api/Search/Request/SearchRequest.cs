namespace Notion.Client
{
    public class SearchRequest : ISearchBodyParameters
    {
        public string Query { get; set; }

        public SearchSort Sort { get; set; }

        public SearchFilter Filter { get; set; }

        public string StartCursor { get; set; }

        public int? PageSize { get; set; }
    }
}
