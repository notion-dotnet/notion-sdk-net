using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Notion.Client;
using Xunit;

namespace Notion.UnitTests;

public class UpdatePropertyConfigurationRequestSerializationTests
{
    private string SerializeRequest<T>(UpdatePropertyConfigurationRequest<T> request) where T : DataSourcePropertyConfigRequest
    {
        // Use JsonConvert.SerializeObject directly - this should now work with our converter factory
        return JsonConvert.SerializeObject(request);
    }

    [Fact]
    public void UpdatePropertyConfigurationRequest_Should_Flatten_PropertyRequest_Into_Parent_Object_Via_JsonConvert()
    {
        // Arrange
        var request = new UpdatePropertyConfigurationRequest<TitleDataSourcePropertyConfigRequest>
        {
            Name = "Test Property Name",
            PropertyRequest = new TitleDataSourcePropertyConfigRequest
            {
                Type = "title",
                Description = "Test description",
                Title = new Dictionary<string, object>
                    {
                        { "some_title_config", "value" }
                    }
            }
        };

        // Act - Using JsonConvert.SerializeObject which automatically uses the JsonConverter attribute
        var json = SerializeRequest(request);

        // Assert
        Assert.Contains("\"name\":\"Test Property Name\"", json);
        Assert.Contains("\"type\":\"title\"", json);
        Assert.Contains("\"description\":\"Test description\"", json);
        Assert.Contains("\"title\":{\"some_title_config\":\"value\"}", json);

        // Verify that PropertyRequest is not present as a separate property
        Assert.DoesNotContain("\"PropertyRequest\"", json);
        Assert.DoesNotContain("\"propertyRequest\"", json);
    }

    [Fact]
    public void UpdatePropertyConfigurationRequestConverter_Should_Serialize_Only_Name_When_PropertyRequest_Is_Null()
    {
        // Arrange
        var request = new UpdatePropertyConfigurationRequest<TitleDataSourcePropertyConfigRequest>
        {
            Name = "Test Property Name",
            PropertyRequest = null
        };

        // Act
        var json = SerializeRequest(request);

        // Assert
        Assert.Contains("\"name\":\"Test Property Name\"", json);
        Assert.DoesNotContain("\"type\"", json);
        Assert.DoesNotContain("\"description\"", json);
        Assert.DoesNotContain("\"title\"", json);
        Assert.DoesNotContain("\"PropertyRequest\"", json);
        Assert.DoesNotContain("\"propertyRequest\"", json);
    }

    [Fact]
    public void UpdatePropertyConfigurationRequestConverter_Should_Serialize_Only_PropertyRequest_Fields_When_Name_Is_Null()
    {
        // Arrange
        var request = new UpdatePropertyConfigurationRequest<TitleDataSourcePropertyConfigRequest>
        {
            Name = null,
            PropertyRequest = new TitleDataSourcePropertyConfigRequest
            {
                Type = "title",
                Description = "Test description",
                Title = new Dictionary<string, object>
                    {
                        { "some_title_config", "value" }
                    }
            }
        };

        // Act
        var json = SerializeRequest(request);

        // Assert
        Assert.DoesNotContain("\"name\"", json);
        Assert.Contains("\"type\":\"title\"", json);
        Assert.Contains("\"description\":\"Test description\"", json);
        Assert.Contains("\"title\":{\"some_title_config\":\"value\"}", json);
        Assert.DoesNotContain("\"PropertyRequest\"", json);
        Assert.DoesNotContain("\"propertyRequest\"", json);
    }

    [Fact]
    public void UpdatePropertyConfigurationRequestConverter_Should_Serialize_Empty_Object_When_Both_Name_And_PropertyRequest_Are_Null()
    {
        // Arrange
        var request = new UpdatePropertyConfigurationRequest<TitleDataSourcePropertyConfigRequest>
        {
            Name = null,
            PropertyRequest = null
        };

        // Act
        var json = SerializeRequest(request);

        // Assert
        Assert.Equal("{}", json);
    }

    [Fact]
    public void UpdatePropertyConfigurationRequestConverter_Should_Flatten_Different_Property_Types()
    {
        // Test with CheckboxPropertyConfigurationRequest
        var checkboxRequest = new UpdatePropertyConfigurationRequest<CheckboxDataSourcePropertyConfigRequest>
        {
            Name = "Checkbox Property",
            PropertyRequest = new CheckboxDataSourcePropertyConfigRequest
            {
                Type = "checkbox",
                Description = "Checkbox description",
                Checkbox = new Dictionary<string, object>
                    {
                        { "checkbox_config", true }
                    }
            }
        };

        var checkboxJson = SerializeRequest(checkboxRequest);

        Assert.Contains("\"name\":\"Checkbox Property\"", checkboxJson);
        Assert.Contains("\"type\":\"checkbox\"", checkboxJson);
        Assert.Contains("\"description\":\"Checkbox description\"", checkboxJson);
        Assert.Contains("\"checkbox\":{\"checkbox_config\":true}", checkboxJson);
        Assert.DoesNotContain("\"PropertyRequest\"", checkboxJson);
    }

    [Fact]
    public void UpdatePropertyConfigurationRequestConverter_Should_Handle_PropertyRequest_With_AdditionalData()
    {
        // Arrange
        var request = new UpdatePropertyConfigurationRequest<TitleDataSourcePropertyConfigRequest>
        {
            Name = "Test Property",
            PropertyRequest = new TitleDataSourcePropertyConfigRequest
            {
                Type = "title",
                Description = "Test description",
                Title = new Dictionary<string, object>
                    {
                        { "some_title_config", "value" }
                    },
                AdditionalData = new Dictionary<string, object>
                    {
                        { "custom_field", "custom_value" },
                        { "another_field", 42 }
                    }
            }
        };

        // Act
        var json = SerializeRequest(request);

        // Assert
        Assert.Contains("\"name\":\"Test Property\"", json);
        Assert.Contains("\"type\":\"title\"", json);
        Assert.Contains("\"description\":\"Test description\"", json);
        Assert.Contains("\"title\":{\"some_title_config\":\"value\"}", json);
        Assert.Contains("\"custom_field\":\"custom_value\"", json);
        Assert.Contains("\"another_field\":42", json);
        Assert.DoesNotContain("\"PropertyRequest\"", json);
        Assert.DoesNotContain("\"AdditionalData\"", json);
    }

    [Fact]
    public void UpdatePropertyConfigurationRequestConverter_Should_Handle_Complex_Property_Configuration()
    {
        // Test with UniqueIdPropertyConfigurationRequest which has nested objects
        var request = new UpdatePropertyConfigurationRequest<UniqueIdDataSourcePropertyConfigRequest>
        {
            Name = "Unique ID Property",
            PropertyRequest = new UniqueIdDataSourcePropertyConfigRequest
            {
                Type = "unique_id",
                Description = "Unique ID description",
                UniqueId = new UniqueIdDataSourcePropertyConfigRequest.UniqueIdConfiguration
                {
                    Prefix = "TEST-",
                    AdditionalData = new Dictionary<string, object>
                        {
                            { "nested_field", "nested_value" }
                        }
                }
            }
        };

        // Act
        var json = SerializeRequest(request);

        // Assert
        Assert.Contains("\"name\":\"Unique ID Property\"", json);
        Assert.Contains("\"type\":\"unique_id\"", json);
        Assert.Contains("\"description\":\"Unique ID description\"", json);
        Assert.Contains("\"unique_id\":", json);
        Assert.Contains("\"prefix\":\"TEST-\"", json);
        Assert.Contains("\"nested_field\":\"nested_value\"", json);
        Assert.DoesNotContain("\"PropertyRequest\"", json);
    }

    [Fact]
    public void UpdatePropertyConfigurationRequestConverter_Should_Not_Support_Reading()
    {
        // Arrange
        var converter = new UpdatePropertyConfigurationRequestConverter<TitleDataSourcePropertyConfigRequest>();

        // Act & Assert
        Assert.False(converter.CanRead);
    }

    [Fact]
    public void UpdatePropertyConfigurationRequestConverter_ReadJson_Should_Throw_NotImplementedException()
    {
        // Arrange
        var converter = new UpdatePropertyConfigurationRequestConverter<TitleDataSourcePropertyConfigRequest>();

        // Act & Assert
        Assert.Throws<NotImplementedException>(() =>
            converter.ReadJson(null, typeof(UpdatePropertyConfigurationRequest<TitleDataSourcePropertyConfigRequest>), null, false, new JsonSerializer()));
    }
}
