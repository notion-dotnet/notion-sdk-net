using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.AutoMock;
using Newtonsoft.Json;
using Notion.Client;
using Xunit;

namespace Notion.UnitTests;

public class FileUploadsClientTests
{
    private readonly AutoMocker _mocker = new();
    private readonly FileUploadsClient _fileUploadClient;
    private readonly Mock<IRestClient> _restClientMock;

    public FileUploadsClientTests()
    {
        _restClientMock = _mocker.GetMock<IRestClient>();
        _fileUploadClient = _mocker.CreateInstance<FileUploadsClient>();
    }

    [Fact]
    public async Task CreateAsync_ThrowsArgumentNullException_WhenRequestIsNull()
    {
        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _fileUploadClient.CreateAsync(null));
        Assert.Equal("fileUploadObjectRequest", exception.ParamName);
        Assert.Equal("Value cannot be null. (Parameter 'fileUploadObjectRequest')", exception.Message);
    }

    [Fact]
    public async Task CreateAsync_CallsRestClientPostAsync_WithCorrectParameters()
    {
        // Arrange
        var request = new CreateFileUploadRequest
        {
            FileName = "testfile.txt",
            Mode = FileUploadMode.SinglePart,
        };

        var expectedResponse = new FileUpload
        {
            UploadUrl = "https://example.com/upload",
            Id = Guid.NewGuid().ToString(),
        };

        _restClientMock
            .Setup(client => client.PostAsync<FileUpload>(
                It.Is<string>(url => url == ApiEndpoints.FileUploadsApiUrls.Create()),
                It.IsAny<ICreateFileUploadBodyParameters>(),
                It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                It.IsAny<IDictionary<string, string>>(),
                It.IsAny<JsonSerializerSettings>(),
                It.IsAny<IBasicAuthenticationParameters>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResponse);

        // Act
        var response = await _fileUploadClient.CreateAsync(request);

        // Assert
        Assert.Equal(expectedResponse.UploadUrl, response.UploadUrl);
        Assert.Equal(expectedResponse.Id, response.Id);

        _restClientMock.VerifyAll();
    }

    [Fact]
    public async Task SendAsync_ThrowsArgumentNullException_WhenRequestIsNull()
    {
        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _fileUploadClient.SendAsync(null));
        Assert.Equal("sendFileUploadRequest", exception.ParamName);
        Assert.Equal("Value cannot be null. (Parameter 'sendFileUploadRequest')", exception.Message);
    }

    [Fact]
    public async Task SendAsync_ThrowsArgumentNullException_WhenFileUploadIdIsNullOrEmpty()
    {
        // Arrange
        var request = SendFileUploadRequest.Create(fileUploadId: null, file: new FileData { FileName = "testfile.txt", Data = new System.IO.MemoryStream(), ContentType = "text/plain" });

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _fileUploadClient.SendAsync(request));
        Assert.Equal("FileUploadId", exception.ParamName);
        Assert.Equal("Value cannot be null. (Parameter 'FileUploadId')", exception.Message);
    }

    [Theory]
    [InlineData("0")]
    [InlineData("1001")]
    [InlineData("-5")]
    [InlineData("abc")]
    public async Task SendAsync_ThrowsArgumentOutOfRangeException_WhenPartNumberIsInvalid(string partNumber)
    {
        // Arrange
        var request = SendFileUploadRequest.Create(fileUploadId: "valid-id", file: new FileData { FileName = "testfile.txt", Data = new System.IO.MemoryStream(), ContentType = "text/plain" }, partNumber: partNumber);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _fileUploadClient.SendAsync(request));
        Assert.Equal("PartNumber", exception.ParamName);
        Assert.Contains("PartNumber must be between 1 and 1000.", exception.Message);
    }

    [Theory]
    [InlineData("1")]
    [InlineData("500")]
    [InlineData("1000")]
    public async Task SendAsync_DoesNotThrow_WhenPartNumberIsValid(string partNumber)
    {
        // Arrange
        var request = SendFileUploadRequest.Create(fileUploadId: "valid-id", file: new FileData { FileName = "testfile.txt", Data = new System.IO.MemoryStream(), ContentType = "text/plain" }, partNumber: partNumber);

        var expectedResponse = new FileUpload
        {
            Id = "valid-id",
            Status = "uploaded",
        };

        _restClientMock
            .Setup(client => client.PostAsync<FileUpload>(
                It.Is<string>(url => url == ApiEndpoints.FileUploadsApiUrls.Send("valid-id")),
                It.IsAny<ISendFileUploadFormDataParameters>(),
                It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                It.IsAny<IDictionary<string, string>>(),
                It.IsAny<JsonSerializerSettings>(),
                It.IsAny<IBasicAuthenticationParameters>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResponse);

        // Act
        var exception = await Record.ExceptionAsync(() => _fileUploadClient.SendAsync(request));

        // Assert
        Assert.Null(exception);
        _restClientMock.VerifyAll();
    }

    [Fact]
    public async Task SendAsync_CallsRestClientPostAsync_WithCorrectParameters()
    {
        // Arrange
        var fileUploadId = Guid.NewGuid().ToString();
        var request = SendFileUploadRequest.Create(
            fileUploadId: fileUploadId,
            file: new FileData
            {
                FileName = "testfile.txt",
                Data = new System.IO.MemoryStream(),
                ContentType = "text/plain"
            }
        );

        var expectedResponse = new FileUpload
        {
            Id = fileUploadId.ToString(),
            Status = "uploaded",
        };

        _restClientMock
            .Setup(client => client.PostAsync<FileUpload>(
                It.Is<string>(url => url == ApiEndpoints.FileUploadsApiUrls.Send(fileUploadId)),
                It.IsAny<ISendFileUploadFormDataParameters>(),
                It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                It.IsAny<IDictionary<string, string>>(),
                It.IsAny<JsonSerializerSettings>(),
                It.IsAny<IBasicAuthenticationParameters>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResponse);
        // Act
        var response = await _fileUploadClient.SendAsync(request);

        // Assert
        Assert.Equal(expectedResponse.Status, response.Status);
        Assert.Equal(expectedResponse.Id, response.Id);
        _restClientMock.VerifyAll();
    }

    #region ListAsync Tests

    [Fact]
    public async Task ListAsync_CallsRestClientGetAsync_WithCorrectParameters()
    {
        // Arrange
        var request = new ListFileUploadsRequest
        {
            PageSize = 10,
            StartCursor = "cursor123",
            Status = "completed"
        };

        _restClientMock
            .Setup(client => client.GetAsync<ListFileUploadsResponse>(
                It.Is<string>(url => url == ApiEndpoints.FileUploadsApiUrls.List),
                It.IsAny<IDictionary<string, string>>(),
                null,
                null,
                It.IsAny<CancellationToken>()
            ))
            .ReturnsAsync(new ListFileUploadsResponse
            {
                Results = new List<FileUpload>
                {
                    new() { Id = "file1", Status = "completed" },
                    new() { Id = "file2", Status = "completed" }
                }
            });

        // Act
        var response = await _fileUploadClient.ListAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(2, response.Results.Count);
        _restClientMock.VerifyAll();
    }

    #endregion ListAsync Tests

    #region RetrieveAsync Tests

    // Add tests for RetrieveAsync method
    [Fact]
    public async Task RetrieveAsync_ThrowsArgumentNullException_WhenFileUploadIdIsNullOrEmpty()
    {
        // Arrange
        var request = new RetrieveFileUploadRequest
        {
            FileUploadId = null
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _fileUploadClient.RetrieveAsync(request));
        Assert.Equal("FileUploadId", exception.ParamName);
        Assert.Equal("FileUploadId cannot be null or empty. (Parameter 'FileUploadId')", exception.Message);
    }

    [Fact]
    public async Task RetrieveAsync_CallsRestClientGetAsync_WithCorrectParameters()
    {
        // Arrange
        var fileUploadId = Guid.NewGuid().ToString();
        var request = new RetrieveFileUploadRequest
        {
            FileUploadId = fileUploadId
        };

        var expectedResponse = new FileUpload
        {
            Id = fileUploadId,
            FileName = "testfile.txt",
            Status = "completed"
        };

        _restClientMock
            .Setup(client => client.GetAsync<FileUpload>(
                It.Is<string>(url => url == ApiEndpoints.FileUploadsApiUrls.Retrieve(request)),
                It.IsAny<IDictionary<string, string>>(),
                null,
                null,
                It.IsAny<CancellationToken>()
            ))
            .ReturnsAsync(expectedResponse);

        // Act
        var response = await _fileUploadClient.RetrieveAsync(request);

        // Assert
        Assert.Equal(expectedResponse.Id, response.Id);
        Assert.Equal(expectedResponse.FileName, response.FileName);
        Assert.Equal(expectedResponse.Status, response.Status);
        _restClientMock.VerifyAll();
    }

    #endregion RetrieveAsync Tests
}
