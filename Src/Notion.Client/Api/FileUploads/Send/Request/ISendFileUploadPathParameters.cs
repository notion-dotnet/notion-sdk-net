namespace Notion.Client
{
    public interface ISendFileUploadPathParameters
    {
        /// <summary>
        /// The `file_upload_id` obtained from the `id` of the Create File Upload API response.
        /// </summary>
        string FileUploadId { get; }
    }
}
