using System.IO;
using System.Threading.Tasks;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests
{
    public class FileUploadsClientTests : IntegrationTestBase
    {
        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var request = new CreateFileUploadRequest
            {
                Mode = FileUploadMode.ExternalUrl,
                ExternalUrl = "https://unsplash.com/photos/hOhlYhAiizc/download?ixid=M3wxMjA3fDB8MXxhbGx8fHx8fHx8fHwxNzYwMTkxNzc3fA&force=true",
                FileName = "sample-image.jpg",
            };

            // Act
            var response = await Client.FileUploads.CreateAsync(request);

            // Assert
            Assert.NotNull(response);
            Assert.NotNull(response.Status);
            Assert.Equal("sample-image.jpg", response.FileName);
        }

        [Fact]
        public async Task Verify_file_upload_flow()
        {
            // Arrange
            var createRequest = new CreateFileUploadRequest
            {
                Mode = FileUploadMode.SinglePart,
                FileName = "notion-logo.png",
            };

            var createResponse = await Client.FileUploads.CreateAsync(createRequest);

            using (var fileStream = File.OpenRead("assets/notion-logo.png"))
            {
                var sendRequest = SendFileUploadRequest.Create(
                    createResponse.Id,
                    new FileData
                    {
                        FileName = "notion-logo.png",
                        Data = fileStream,
                        ContentType = createResponse.ContentType
                    }
                );

                // Act
                var sendResponse = await Client.FileUploads.SendAsync(sendRequest);

                // Assert
                Assert.NotNull(sendResponse);
                Assert.Equal(createResponse.Id, sendResponse.Id);
                Assert.Equal("notion-logo.png", sendResponse.FileName);
                Assert.Equal("uploaded", sendResponse.Status);
            }
        }

        [Fact]
        public async Task Verify_multi_part_file_upload_flow()
        {
            // Create file upload
            var createRequest = new CreateFileUploadRequest
            {
                Mode = FileUploadMode.MultiPart,
                FileName = "notion-logo.png",
                NumberOfParts = 2
            };

            var createResponse = await Client.FileUploads.CreateAsync(createRequest);

            Assert.NotNull(createResponse);
            Assert.NotNull(createResponse.Id);
            Assert.Equal("notion-logo.png", createResponse.FileName);
            Assert.Equal("image/png", createResponse.ContentType);
            Assert.Equal("pending", createResponse.Status);

            // Send file parts
            using (var fileStream = File.OpenRead("assets/notion-logo.png"))
            {
                var splitStreams = StreamSplitExtensions.Split(fileStream, 2);

                foreach (var (partStream, index) in splitStreams.WithIndex())
                {
                    var partSendRequest = SendFileUploadRequest.Create(
                        createResponse.Id,
                        new FileData
                        {
                            FileName = "notion-logo.png",
                            Data = partStream,
                            ContentType = createResponse.ContentType
                        },

                        partNumber: (index + 1).ToString()
                    );

                    var partSendResponse = await Client.FileUploads.SendAsync(partSendRequest);

                    Assert.NotNull(partSendResponse);
                    Assert.Equal(createResponse.Id, partSendResponse.Id);
                    Assert.Equal("notion-logo.png", partSendResponse.FileName);
                }

                // Complete file upload
                var completeRequest = new CompleteFileUploadRequest
                {
                    FileUploadId = createResponse.Id
                };

                var completeResponse = await Client.FileUploads.CompleteAsync(completeRequest);

                Assert.NotNull(completeResponse);
                Assert.Equal(createResponse.Id, completeResponse.Id);
                Assert.Equal("notion-logo.png", completeResponse.FileName);
                Assert.Equal("completed", completeResponse.Status);
            }
        }

        [Fact]
        public async Task ListAsync()
        {
            // Arrange
            var request = new ListFileUploadsRequest
            {
                PageSize = 5
            };

            // Act
            var response = await Client.FileUploads.ListAsync(request);

            // Assert
            Assert.NotNull(response);
            Assert.NotNull(response.Results);
            Assert.True(response.Results.Count <= 5);
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            // Arrange
            var createRequest = new CreateFileUploadRequest
            {
                Mode = FileUploadMode.ExternalUrl,
                ExternalUrl = "https://unsplash.com/photos/hOhlYhAiizc/download?ixid=M3wxMjA3fDB8MXxhbGx8fHx8fHx8fHwxNzYwMTkxNzc3fA&force=true",
                FileName = "sample-image.jpg",
            };

            var createResponse = await Client.FileUploads.CreateAsync(createRequest);

            Assert.NotNull(createResponse);
            Assert.NotNull(createResponse.Id);
            Assert.Equal("sample-image.jpg", createResponse.FileName);
            Assert.Equal("image/jpeg", createResponse.ContentType);
            Assert.Equal("pending", createResponse.Status);

            // Act
            var retrieveRequest = new RetrieveFileUploadRequest
            {
                FileUploadId = createResponse.Id
            };

            var retrieveResponse = await Client.FileUploads.RetrieveAsync(retrieveRequest);

            // Assert
            Assert.NotNull(retrieveResponse);
            Assert.Equal(createResponse.Id, retrieveResponse.Id);
            Assert.Equal("sample-image.jpg", retrieveResponse.FileName);
            Assert.Equal("image/jpeg", retrieveResponse.ContentType);
            // The status might have changed from "pending" to "uploaded" depending on Notion's processing time
            Assert.Contains(retrieveResponse.Status, new[] { "pending", "uploaded" });
        }
    }
}
