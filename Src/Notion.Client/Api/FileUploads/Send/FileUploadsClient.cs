using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class FileUploadsClient
    {
        public async Task<FileUpload> SendAsync(
            SendFileUploadRequest sendFileUploadRequest,
            CancellationToken cancellationToken = default)
        {
            if (sendFileUploadRequest == null)
            {
                throw new ArgumentNullException(nameof(sendFileUploadRequest));
            }

            if (string.IsNullOrWhiteSpace(sendFileUploadRequest.FileUploadId))
            {
                throw new ArgumentNullException(nameof(sendFileUploadRequest.FileUploadId));
            }

            if (sendFileUploadRequest.PartNumber != null)
            {
                if (!int.TryParse(sendFileUploadRequest.PartNumber, out int partNumberValue) || partNumberValue < 1 || partNumberValue > 1000)
                {
                    throw new ArgumentOutOfRangeException(nameof(sendFileUploadRequest.PartNumber), "PartNumber must be between 1 and 1000.");
                }
            }

            var path = ApiEndpoints.FileUploadsApiUrls.Send(sendFileUploadRequest.FileUploadId);

            return await _restClient.PostAsync<FileUpload>(
                path,
                formData: sendFileUploadRequest,
                cancellationToken: cancellationToken
            );
        }
    }
}
