using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class FileUploadsClient
    {
        public async Task<FileUpload> CompleteAsync(
            CompleteFileUploadRequest completeFileUploadRequest,
            CancellationToken cancellationToken = default)
        {
            if (completeFileUploadRequest == null)
            {
                throw new ArgumentNullException(nameof(completeFileUploadRequest));
            }

            if (string.IsNullOrEmpty(completeFileUploadRequest.FileUploadId))
            {
                throw new ArgumentException("FileUploadId cannot be null or empty.", nameof(completeFileUploadRequest.FileUploadId));
            }

            var path = ApiEndpoints.FileUploadsApiUrls.Complete(completeFileUploadRequest.FileUploadId);

            return await _restClient.PostAsync<FileUpload>(
                path,
                body: null,
                cancellationToken: cancellationToken
            );
        }
    }
}
