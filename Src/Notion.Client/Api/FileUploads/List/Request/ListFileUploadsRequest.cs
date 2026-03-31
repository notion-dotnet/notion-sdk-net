namespace Notion.Client
{
    public class ListFileUploadsRequest : IListFileUploadsQueryParameters
    {
        public string Status { get; set; }
        public string StartCursor { get; set; }
        public int? PageSize { get; set; }
    }
}
