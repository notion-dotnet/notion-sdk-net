namespace Notion.Client
{
    public interface IRetrieveFileUploadPathParameters
    {
        /// <summary>
        /// The ID of the File Upload to retrieve.
        /// </summary>
        string FileUploadId { get; set; }
    }
}
