using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class FileUploadsClient
    {
        public async Task<FileUpload> CreateAsync(
            CreateFileUploadRequest fileUploadObjectRequest,
            CancellationToken cancellationToken = default)
        {
            if (fileUploadObjectRequest == null)
            {
                throw new ArgumentNullException(nameof(fileUploadObjectRequest));
            }

            ICreateFileUploadBodyParameters body = fileUploadObjectRequest;

            return await _restClient.PostAsync<FileUpload>(
                ApiEndpoints.FileUploadsApiUrls.Create(),
                body,
                cancellationToken: cancellationToken
            );
        }
    }
}
