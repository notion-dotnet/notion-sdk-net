using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests
{
    public class DataSourcesClientTests : IntegrationTestBase, IAsyncLifetime
    {
        private Page _page = null!;

        public async Task InitializeAsync()
        {
            _page = await Client.Pages.CreateAsync(
                PagesCreateParametersBuilder.Create(
                    new PageParentRequest { PageId = ParentPageId }
                ).Build()
            );
        }

        public async Task DisposeAsync()
        {
            await Client.Pages.UpdateAsync(_page.Id, new PagesUpdateParameters { InTrash = true });
        }

        [Fact]
        public async Task CreateDataSource_ShouldReturnSuccess()
        {
            // Arrange
            var database = await CreateDatabaseWithAPageAsync("Test Data Source DB");
            var request = new CreateDataSourceRequest
            {
                Parent = new DatabaseParentRequest
                {
                    DatabaseId = database.Id
                },
                Properties = new Dictionary<string, DataSourcePropertyConfigRequest>
                {
                    {
                        "Name",
                        new TitleDataSourcePropertyConfigRequest {
                            Description = "The name of the data source",
                            Title = new Dictionary<string, object>()
                        }
                    }
                },
                Title = new List<RichTextBaseInput>
                {
                    new RichTextTextInput {  Text =  new Text { Content = "Test Data Source" } }
                }
            };

            // Act
            var response = await Client.DataSources.CreateAsync(request);

            // Assert
            Assert.NotNull(response);
            Assert.Equal("Test Data Source", response.Title.OfType<RichTextText>().First().Text.Content);
            Assert.Single(response.Properties);
            Assert.True(response.Properties.ContainsKey("Name"));
            Assert.Equal("The name of the data source", response.Properties["Name"].Description);
        }
        
        [Fact]
        public async Task DataSource_CanQueryPages()
        {
            // Arrange
            var titlePropertyName = "Name";
            var database = await CreateDatabaseWithAPageAsync("Test Data Source DB");
            var request = new CreateDataSourceRequest
            {
                Parent = new DatabaseParentRequest
                {
                    DatabaseId = database.Id
                },
                Properties = new Dictionary<string, DataSourcePropertyConfigRequest>
                {
                    {
                        titlePropertyName,
                        new TitleDataSourcePropertyConfigRequest {
                            Description = "The name of the data source",
                            Title = new Dictionary<string, object>()
                        }
                    }
                },
                Title = new List<RichTextBaseInput>
                {
                    new RichTextTextInput {  Text =  new Text { Content = "Test Data Source" } }
                }
            };
            var dataSource = await Client.DataSources.CreateAsync(request);
            var page = await Client.Pages.CreateAsync(new PagesCreateParameters
            {
                Children = new List<IBlock>(),
                Parent = new DataSourceParentRequest
                {
                    DataSourceId = dataSource.Id
                },
                Properties = new Dictionary<string, PropertyValue>
                {
                    {titlePropertyName, new TitlePropertyValue {Title = [new RichTextText {Text = new Text {Content = "hello"}}]}}
                }
            });
            var otherPage = await Client.Pages.CreateAsync(new PagesCreateParameters
            {
                Children = new List<IBlock>(),
                Parent = new DataSourceParentRequest
                {
                    DataSourceId = dataSource.Id
                },
                Properties = new Dictionary<string, PropertyValue>
                {
                    {titlePropertyName, new TitlePropertyValue {Title = [new RichTextText {Text = new Text {Content = "xxx"}}]}}
                }
            });
            
            // Act
            var queryResult = await Client.DataSources.QueryAsync(new QueryDataSourceRequest
            {
                DataSourceId = dataSource.Id,
                Filter = new TitleFilter(titlePropertyName, startsWith: "he")
            });

            // Assert
            Assert.NotNull(page);
            Assert.True(queryResult.Results.OfType<Page>().Any());
            Assert.Contains(page.Id, queryResult.Results.Select(x => x.Id));
            Assert.DoesNotContain(otherPage.Id, queryResult.Results.Select(x => x.Id));
        }

        // add tests for update
        [Fact]
        public async Task UpdateDataSource_ShouldReturnSuccess()
        {
            // Arrange
            var database = await CreateDatabaseWithAPageAsync("Test Data Source DB");
            var createRequest = new CreateDataSourceRequest
            {
                Parent = new DatabaseParentRequest
                {
                    DatabaseId = database.Id
                },
                Properties = new Dictionary<string, DataSourcePropertyConfigRequest>
                {
                    {
                        "Name",
                        new TitleDataSourcePropertyConfigRequest {
                            Description = "The name of the data source",
                            Title = new Dictionary<string, object>()
                        }
                    },
                    {
                        "Status",
                        new SelectDataSourcePropertyConfigRequest {
                            Description = "The status of the data source",
                            Select = new SelectDataSourcePropertyConfigRequest.SelectOptions
                            {
                                Options = new List<SelectOptionRequest>
                                {
                                    new() { Name = "Open", Color = "green" },
                                    new() { Name = "Closed", Color = "red" }
                                }
                            }
                        }
                    }
                },
                Title = new List<RichTextBaseInput>
                {
                    new RichTextTextInput {  Text =  new Text { Content = "Initial Data Source" } }
                }
            };

            var createResponse = await Client.DataSources.CreateAsync(createRequest);

            var updateRequest = new UpdateDataSourceRequest
            {
                DataSourceId = createResponse.Id,
                Title = new List<RichTextBaseInput>
                {
                    new RichTextTextInput { Text = new Text { Content = "Updated Data Source" } }
                },
                Properties = new Dictionary<string, IUpdatePropertyConfigurationRequest>
                {
                    {
                        "Status",
                        new UpdatePropertyConfigurationRequest<SelectDataSourcePropertyConfigRequest>
                        {
                            Name = "Item Status",
                            PropertyRequest = new SelectDataSourcePropertyConfigRequest
                            {
                                Description = "Updated status of the data source",
                                Select = new SelectDataSourcePropertyConfigRequest.SelectOptions
                                {
                                    Options = new List<SelectOptionRequest>
                                    {
                                        new() { Name = "In Progress", Color = "yellow" },
                                        new() { Name = "Completed", Color = "blue" }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            // Act
            var updateResponse = await Client.DataSources.UpdateAsync(updateRequest);

            // Assert
            Assert.NotNull(updateResponse);
            Assert.Equal("Updated Data Source", updateResponse.Title.OfType<RichTextText>().First().Text.Content);
            Assert.Equal(2, updateResponse.Properties.Count);
            Assert.True(updateResponse.Properties.ContainsKey("Item Status"));
            Assert.True(updateResponse.Properties.ContainsKey("Name"));
        }

        // write test for query
        [Fact]
        public async Task QueryDataSourceAsync_ShouldReturnResults()
        {
            // Arrange
            var databaseId = "29ee2842ccb5802397b8fdf6fed5ac93"; // TODO: Create a test database and set its ID here
            var dataSourceId = await CreateAndGetDatasourceIdAsync(databaseId);
            var queryRequest = new QueryDataSourceRequest
            {
                DataSourceId = dataSourceId,
            };

            // Act
            var queryResponse = await Client.DataSources.QueryAsync(queryRequest);

            // Assert
            Assert.NotNull(queryResponse);
            Assert.NotNull(queryResponse.Results);
        }

        private async Task<string> CreateAndGetDatasourceIdAsync(string databaseId)
        {
            var request = new CreateDataSourceRequest
            {
                Parent = new DatabaseParentRequest
                {
                    DatabaseId = databaseId
                },
                Properties = new Dictionary<string, DataSourcePropertyConfigRequest>
                {
                    {
                        "Name",
                        new TitleDataSourcePropertyConfigRequest {
                            Description = "The name of the data source",
                            Title = new Dictionary<string, object>()
                        }
                    }
                },
                Title = new List<RichTextBaseInput>
                {
                    new RichTextTextInput {  Text =  new Text { Content = "Test Data Source" } }
                }
            };

            var response = await Client.DataSources.CreateAsync(request);
            return response.Id;
        }

        [Fact]
        public async Task UpdateDatabaseRelationProperties()
        {
            // Arrange
            var createdSourceDatabase = await CreateDatabaseWithAPageAsync("Test Relation Source");
            var createdDestinationDatabase = await CreateDatabaseWithAPageAsync("Test Relation Destination");

            // Act
            var response = await Client.DataSources.UpdateAsync(
                new UpdateDataSourceRequest
                {
                    DataSourceId = createdDestinationDatabase.DataSources.First().DataSourceId,
                    Properties = new Dictionary<string, IUpdatePropertyConfigurationRequest>
                    {
                        {
                            "Single Relation",
                            new UpdatePropertyConfigurationRequest<RelationDataSourcePropertyConfigRequest>
                            {
                                Name = "Single Relation",
                                PropertyRequest = new RelationDataSourcePropertyConfigRequest
                                {
                                    Relation = new SinglePropertyRelationInfoRequest
                                    {
                                        DataSourceId = createdSourceDatabase.DataSources.First().DataSourceId,
                                        SingleProperty = new Dictionary<string, object>()
                                    }
                                }
                            }
                        },
                        {
                            "Dual Relation",
                            new UpdatePropertyConfigurationRequest<RelationDataSourcePropertyConfigRequest>
                            {
                                Name = "Dual Relation",
                                PropertyRequest = new RelationDataSourcePropertyConfigRequest
                                {
                                    Relation = new DualPropertyRelationInfoRequest
                                    {
                                        DataSourceId = createdSourceDatabase.DataSources.First().DataSourceId,
                                        DualProperty = new DualPropertyRelationInfoRequest.Data()
                                    }
                                }
                            }
                        }
                    }
                });

            // Assert
            await ValidateDatasourceProperties(createdDestinationDatabase.DataSources.First().DataSourceId, createdSourceDatabase.DataSources.First().DataSourceId);
        }

        private async Task ValidateDatasourceProperties(string dataSourceId, string sourceDataSourceId)
        {
            var response = await Client.DataSources.RetrieveAsync(new RetrieveDataSourceRequest { DataSourceId = dataSourceId });

            response.Properties.Should().NotBeNull();

            response.Properties.Should().ContainKey("Single Relation");
            var singleRelation = response.Properties["Single Relation"].As<RelationDataSourcePropertyConfig>().Relation;
            singleRelation.Type.Should().Be("single_property");
            var singleRelationData = singleRelation.Should().BeOfType<SinglePropertyRelationInfo>().Subject;
            singleRelationData.DataSourceId.Should().Be(sourceDataSourceId);

            response.Properties.Should().ContainKey("Dual Relation");
            var dualRelation = response.Properties["Dual Relation"].As<RelationDataSourcePropertyConfig>().Relation;
            dualRelation.DataSourceId.Should().Be(sourceDataSourceId);
            dualRelation.Type.Should().Be("dual_property");
            dualRelation.Should().BeOfType<DualPropertyRelationInfo>();
        }

        private async Task<Database> CreateDatabaseWithAPageAsync(string databaseName)
        {
            var createDbRequest = new DatabasesCreateRequest
            {
                Title = new List<RichTextBaseInput>
                {
                    new RichTextTextInput
                    {
                        Text = new Text
                        {
                            Content = databaseName,
                            Link = null
                        }
                    }
                },
                InitialDataSource = new InitialDataSourceRequest
                {
                    Properties = new Dictionary<string, DataSourcePropertyConfigRequest>
                    {
                        { "Name", new TitleDataSourcePropertyConfigRequest { Title = new Dictionary<string, object>() } },
                    }
                },
                Parent = new PageParentOfDatabaseRequest { PageId = _page.Id }
            };

            var createdDatabase = await Client.Databases.CreateAsync(createDbRequest);

            var pagesCreateParameters = PagesCreateParametersBuilder
                .Create(new DatabaseParentRequest { DatabaseId = createdDatabase.Id })
                .AddProperty("Name",
                    new TitlePropertyValue
                    {
                        Title = new List<RichTextBase>
                        {
                            new RichTextText { Text = new Text { Content = "Test Title" } }
                        }
                    })
                .Build();

            await Client.Pages.CreateAsync(pagesCreateParameters);

            return createdDatabase;
        }
    }
}