using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.AutoMock;
using Newtonsoft.Json;
using Notion.Client;
using Xunit;

namespace Notion.UnitTests.AuthenticationClientTest;

public class RefreshTokenApiTests
{
    private readonly AutoMocker _mocker = new();
    private readonly Mock<IRestClient> _restClientMock;
    private readonly AuthenticationClient _authenticationClient;

    public RefreshTokenApiTests()
    {
        _restClientMock = _mocker.GetMock<IRestClient>();
        _authenticationClient = _mocker.CreateInstance<AuthenticationClient>();
    }

    [Fact]
    public async Task RefreshTokenAsync_ThrowsArgumentNullException_WhenRequestIsNull()
    {
        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _authenticationClient.RefreshTokenAsync(null));
        Assert.Equal("refreshTokenRequest", exception.ParamName);
        Assert.Equal("Value cannot be null. (Parameter 'refreshTokenRequest')", exception.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task RefreshTokenAsync_ThrowsArgumentNullException_WhenRefreshTokenIsNullOrEmpty(string refreshToken)
    {
        // Arrange
        var request = new RefreshTokenRequest
        {
            RefreshToken = refreshToken,
            ClientId = "validClientId",
            ClientSecret = "validClientSecret"
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _authenticationClient.RefreshTokenAsync(request));
        Assert.Equal("RefreshToken", exception.ParamName);
        Assert.Equal("RefreshToken is required. (Parameter 'RefreshToken')", exception.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task RefreshTokenAsync_ThrowsArgumentException_WhenClientIdIsNullOrEmpty(string clientId)
    {
        // Arrange
        var request = new RefreshTokenRequest
        {
            RefreshToken = "validRefreshToken",
            ClientId = clientId,
            ClientSecret = "validClientSecret"
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _authenticationClient.RefreshTokenAsync(request));
        Assert.Equal("ClientId", exception.ParamName);
        Assert.Equal("ClientId must be provided. (Parameter 'ClientId')", exception.Message);
    }

    [Fact]
    public async Task RefreshTokenAsync_ReturnsRefreshTokenResponse_WhenRequestIsValid()
    {
        // Arrange
        var refreshTokenRequest = new RefreshTokenRequest
        {
            RefreshToken = "validRefreshToken",
            ClientId = "validClientId",
            ClientSecret = "validClientSecret"
        };

        var mockResponse = new RefreshTokenResponse
        {
            AccessToken = "mockAccessToken",
            RefreshToken = "mockRefreshToken",
            BotId = "mockBotId",
            DuplicatedTemplateId = "mockDuplicatedTemplateId",
            Owner = new Owner
            {
                Workspace = true
            },
            WorkspaceIcon = "mockWorkspaceIcon",
            WorkspaceName = "mockWorkspaceName",
            WorkspaceId = "mockWorkspaceId"
        };

        _restClientMock
            .Setup(client => client.PostAsync<RefreshTokenResponse>(
                ApiEndpoints.AuthenticationUrls.RefreshToken(),
                It.IsAny<IRefreshTokenBodyParameters>(),
                It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                It.IsAny<Dictionary<string, string>>(),
                It.IsAny<JsonSerializerSettings>(),
                It.IsAny<IBasicAuthenticationParameters>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockResponse);

        // Act
        var response = await _authenticationClient.RefreshTokenAsync(refreshTokenRequest);

        // Assert
        Assert.NotNull(response);
        Assert.IsType<RefreshTokenResponse>(response);
        Assert.Equal("mockAccessToken", response.AccessToken);
        Assert.Equal("mockRefreshToken", response.RefreshToken);
        Assert.Equal("mockBotId", response.BotId);
        Assert.Equal("mockDuplicatedTemplateId", response.DuplicatedTemplateId);
        Assert.NotNull(response.Owner);
        Assert.True(response.Owner.Workspace);
        Assert.Equal("mockWorkspaceIcon", response.WorkspaceIcon);
        Assert.Equal("mockWorkspaceName", response.WorkspaceName);
    }
}