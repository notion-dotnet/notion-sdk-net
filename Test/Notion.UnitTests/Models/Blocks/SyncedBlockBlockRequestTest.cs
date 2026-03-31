using System.Collections.Generic;
using Newtonsoft.Json;
using Notion.Client;
using Xunit;
using FluentAssertions;

namespace Notion.UnitTests.Models.Blocks.Request;

public class SyncedBlockBlockRequestTest
{
    [Fact]
    public void Serializes_SyncedFrom_Null_As_Explicit_Null()
    {
        // Arrange
        var request = new SyncedBlockBlockRequest
        {
            SyncedBlock = new SyncedBlockBlockRequest.Data
            {
                SyncedFrom = null,
                Children = new List<ISyncedBlockChildrenRequest>()
            }
        };

        // Act
        var json = JsonConvert.SerializeObject(request, RestClient.DefaultSerializerSettings);

        // Assert
        json.Should().Contain(@"""synced_from"":null");
    }

    [Fact]
    public void Serializes_SyncedFrom_With_BlockId()
    {
        // Arrange
        var request = new SyncedBlockBlockRequest
        {
            SyncedBlock = new SyncedBlockBlockRequest.Data
            {
                SyncedFrom = new SyncedBlockBlockRequest.Data.SyncedFromBlockId
                {
                    Type = "block_id",
                    BlockId = "abc123"
                },
                Children = new List<ISyncedBlockChildrenRequest>()
            }
        };

        // Act
        var json = JsonConvert.SerializeObject(request, RestClient.DefaultSerializerSettings);

        // Assert
        json.Should().Contain(@"""synced_from"":{");
        json.Should().Contain(@"""type"":""block_id""");
        json.Should().Contain(@"""block_id"":""abc123""");
    }
}
