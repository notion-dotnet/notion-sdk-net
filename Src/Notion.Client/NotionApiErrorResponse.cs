namespace Notion.Client
{
    class NotionApiErrorResponse
    {
        public NotionAPIErrorCode ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
