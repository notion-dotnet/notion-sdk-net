namespace Notion.Client
{
    public class RetrievePropertyItemParameters : IRetrievePropertyItemPathParameters, IRetrievePropertyQueryParameters
    {
        public string PageId { get; set; }

        public string PropertyId { get; set; }

        public string StartCursor { get; set; }

        public int? PageSize { get; set; }
    }
}
