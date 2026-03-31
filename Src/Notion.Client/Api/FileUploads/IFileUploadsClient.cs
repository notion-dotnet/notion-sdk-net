using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IFileUploadsClient
    {
        /// <summary>
        /// Use this API to initiate the process of uploading a file to your Notion workspace.
        /// </summary>
        /// <param name="fileUploadObjectRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<FileUpload> CreateAsync(
            CreateFileUploadRequest fileUploadObjectRequest,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Send a file upload
        /// 
        /// Requires a `file_upload_id`, obtained from the `id` of the Create File Upload API response.
        /// 
        /// </summary>
        /// <param name="sendFileUploadRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<FileUpload> SendAsync(
            SendFileUploadRequest sendFileUploadRequest,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// After uploading all parts of a file (mode=multi_part), call this endpoint to complete the upload process.
        /// </summary>
        /// <param name="completeFileUploadRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<FileUpload> CompleteAsync(
            CompleteFileUploadRequest completeFileUploadRequest,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// List File Uploads for the current bot integration, sorted by most recent first.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ListFileUploadsResponse> ListAsync(
            ListFileUploadsRequest request,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Retrieve a specific File Upload by its ID.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<FileUpload> RetrieveAsync(
            RetrieveFileUploadRequest request,
            CancellationToken cancellationToken = default
        );
    }
}
