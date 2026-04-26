namespace Notion.Client
{
    public class RetrievePageAsMarkdownRequest :
        IRetrievePageAsMarkdownPathParameters,
        IRetrievePageAsMarkdownQueryParameters
    {
        public string PageId { get; set; }
        public bool IncludeTranscript { get; set; }
    }
}
