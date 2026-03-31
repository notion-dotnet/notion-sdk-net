using System.Collections.Generic;
using Newtonsoft.Json;
using Notion.Client;
using Xunit;

namespace Notion.UnitTests
{
    public class UpdatePropertyConfigurationRequestConverterFactoryTests
    {
        [Fact]
        public void ConverterFactory_WithSelectProperty_ShouldSerializeCorrectly()
        {
            // Arrange
            var request = new UpdatePropertyConfigurationRequest<SelectDataSourcePropertyConfigRequest>
            {
                Name = "Status",
                PropertyRequest = new SelectDataSourcePropertyConfigRequest
                {
                    Description = "Task status",
                    Select = new SelectDataSourcePropertyConfigRequest.SelectOptions
                    {
                        Options = new List<SelectOptionRequest>
                        {
                            new SelectOptionRequest { Name = "Done", Color = "green" }
                        }
                    }
                }
            };

            // Cast to non-generic interface to simulate real usage
            IUpdatePropertyConfigurationRequest nonGenericRequest = request;

            // Act
            var json = JsonConvert.SerializeObject(nonGenericRequest);

            // Assert
            Assert.Contains("\"name\":\"Status\"", json);
            Assert.Contains("\"description\":\"Task status\"", json);
            Assert.Contains("\"select\"", json);
            Assert.Contains("\"options\"", json);
            Assert.Contains("\"Done\"", json);
            Assert.Contains("\"green\"", json);
        }

        [Fact]
        public void ConverterFactory_WithTitleProperty_ShouldSerializeCorrectly()
        {
            // Arrange
            var request = new UpdatePropertyConfigurationRequest<TitleDataSourcePropertyConfigRequest>
            {
                Name = "Task Name",
                PropertyRequest = new TitleDataSourcePropertyConfigRequest
                {
                    Description = "Name of the task"
                }
            };

            // Cast to non-generic interface to simulate real usage
            IUpdatePropertyConfigurationRequest nonGenericRequest = request;

            // Act
            var json = JsonConvert.SerializeObject(nonGenericRequest);

            // Assert
            Assert.Contains("\"name\":\"Task Name\"", json);
            Assert.Contains("\"description\":\"Name of the task\"", json);
            Assert.Contains("\"title\"", json);
        }

        [Fact]
        public void ConverterFactory_WithDictionary_ShouldSerializeAllProperties()
        {
            // Arrange
            var properties = new Dictionary<string, IUpdatePropertyConfigurationRequest>
            {
                {
                    "Status",
                    new UpdatePropertyConfigurationRequest<SelectDataSourcePropertyConfigRequest>
                    {
                        Name = "Status",
                        PropertyRequest = new SelectDataSourcePropertyConfigRequest
                        {
                            Description = "Task status"
                        }
                    }
                },
                {
                    "Title",
                    new UpdatePropertyConfigurationRequest<TitleDataSourcePropertyConfigRequest>
                    {
                        Name = "Task Name",
                        PropertyRequest = new TitleDataSourcePropertyConfigRequest
                        {
                            Description = "Name of the task"
                        }
                    }
                }
            };

            // Act
            var json = JsonConvert.SerializeObject(properties);

            // Assert
            Assert.Contains("\"Status\"", json);
            Assert.Contains("\"Title\"", json);
            Assert.Contains("\"Task status\"", json);
            Assert.Contains("\"Name of the task\"", json);
            Assert.Contains("\"select\"", json);
            Assert.Contains("\"title\"", json);
        }
    }
}