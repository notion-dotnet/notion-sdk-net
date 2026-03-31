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

public class AuthenticationClientTests
{
    private readonly AutoMocker _mocker = new();
    private readonly Mock<IRestClient> _restClientMock;
    private readonly AuthenticationClient _authenticationClient;

    public AuthenticationClientTests()
    {
        _restClientMock = _mocker.GetMock<IRestClient>();
        _authenticationClient = _mocker.CreateInstance<AuthenticationClient>();
    }

    [Fact]
    public async Task IntrospectTokenAsync_ThrowsArgumentNullException_WhenRequestIsNull()
    {
        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _authenticationClient.IntrospectTokenAsync(null));
        Assert.Equal("introspectTokenRequest", exception.ParamName);
        Assert.Equal("Value cannot be null. (Parameter 'introspectTokenRequest')", exception.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task IntrospectTokenAsync_ThrowsArgumentException_WhenTokenIsNullOrEmpty(string token)
    {
        // Arrange
        var request = new IntrospectTokenRequest
        {
            Token = token,
            ClientId = "validClientId",
            ClientSecret = "validClientSecret"
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _authenticationClient.IntrospectTokenAsync(request));
        Assert.Equal("Token", exception.ParamName);
        Assert.Equal("Token must be provided. (Parameter 'Token')", exception.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task IntrospectTokenAsync_ThrowsArgumentException_WhenClientIdIsNullOrEmpty(string clientId)
    {
        // Arrange
        var request = new IntrospectTokenRequest
        {
            Token = "validToken",
            ClientId = clientId,
            ClientSecret = "validClientSecret"
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _authenticationClient.IntrospectTokenAsync(request));
        Assert.Equal("ClientId", exception.ParamName);
        Assert.Equal("ClientId must be provided. (Parameter 'ClientId')", exception.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task IntrospectTokenAsync_ThrowsArgumentException_WhenClientSecretIsNullOrEmpty(string clientSecret)
    {
        // Arrange
        var request = new IntrospectTokenRequest
        {
            Token = "validToken",
            ClientId = "validClientId",
            ClientSecret = clientSecret
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _authenticationClient.IntrospectTokenAsync(request));
        Assert.Equal("ClientSecret", exception.ParamName);
        Assert.Equal("ClientSecret must be provided. (Parameter 'ClientSecret')", exception.Message);
    }

    [Fact]
    public async Task IntrospectTokenAsync_CallsPostAsync_WithCorrectParameters()
    {
        // Arrange
        var introspectTokenRequest = new IntrospectTokenRequest
        {
            Token = "validToken",
            ClientId = "validClientId",
            ClientSecret = "validClientSecret"
        };

        var expectedResponse = new IntrospectTokenResponse
        {
            IsActive = true,
            Scope = "read write",
            Iat = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        _restClientMock
            .Setup(client => client.PostAsync<IntrospectTokenResponse>(
                It.Is<string>(url => url == ApiEndpoints.AuthenticationUrls.IntrospectToken()),
                It.IsAny<IIntrospectTokenBodyParameters>(),
                It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                It.IsAny<IDictionary<string, string>>(),
                It.IsAny<JsonSerializerSettings>(),
                It.IsAny<IBasicAuthenticationParameters>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResponse);

        // Act
        var response = await _authenticationClient.IntrospectTokenAsync(introspectTokenRequest);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(expectedResponse.IsActive, response.IsActive);
        Assert.Equal(expectedResponse.Scope, response.Scope);
        Assert.Equal(expectedResponse.Iat, response.Iat);
        _restClientMock.VerifyAll();
    }
}