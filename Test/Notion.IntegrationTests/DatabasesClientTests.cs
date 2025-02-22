using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class DatabasesClientTests : IntegrationTestBase, IAsyncLifetime
{
    private Page _page = null!;

    public async Task InitializeAsync()
    {
        _page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(
                new ParentPageInput { PageId = ParentPageId }
            ).Build()
        );
    }

    public async Task DisposeAsync()
    {
        await Client.Pages.UpdateAsync(_page.Id, new PagesUpdateParameters { InTrash = true });
    }

    [Fact]
    public async Task QueryDatabase()
    {
        // Arrange
        var createdDatabase = await CreateDatabaseWithAPageAsync("Test List");

        // Act
        var response = await Client.Databases.QueryAsync(createdDatabase.Id, new DatabasesQueryParameters());

        // Assert
        response.Results.Should().NotBeNull();
        var page = response.Results.Should().ContainSingle().Subject.As<Page>();

        page.Properties["Name"].As<TitlePropertyValue>()
            .Title.Cast<RichTextText>().First()
            .Text.Content.Should().Be("Test Title");
    }

    [Fact]
    public async Task UpdateDatabaseRelationProperties()
    {
        // Arrange
        var createdSourceDatabase = await CreateDatabaseWithAPageAsync("Test Relation Source");
        var createdDestinationDatabase = await CreateDatabaseWithAPageAsync("Test Relation Destination");

        // Act
        var response = await Client.Databases.UpdateAsync(createdDestinationDatabase.Id,
            new DatabasesUpdateParameters
            {
                Properties = new Dictionary<string, IUpdatePropertySchema>
                {
                    {
                        "Single Relation",
                        new RelationUpdatePropertySchema
                        {
                            Relation = new SinglePropertyRelation
                            {
                                DatabaseId = createdSourceDatabase.Id,
                                SingleProperty = new Dictionary<string, object>()
                            }
                        }
                    },
                    {
                        "Dual Relation",
                        new RelationUpdatePropertySchema
                        {
                            Relation = new DualPropertyRelation
                            {
                                DatabaseId = createdSourceDatabase.Id,
                                DualProperty = new DualPropertyRelation.Data()
                            }
                        }
                    }
                }
            });

        // Assert
        response.Properties.Should().NotBeNull();

        response.Properties.Should().ContainKey("Single Relation");
        var singleRelation = response.Properties["Single Relation"].As<RelationProperty>().Relation;
        singleRelation.Should().BeEquivalentTo(
            new SinglePropertyRelation
            {
                DatabaseId = createdSourceDatabase.Id,
                SingleProperty = new Dictionary<string, object>()
            });

        response.Properties.Should().ContainKey("Dual Relation");
        var dualRelation = response.Properties["Dual Relation"].As<RelationProperty>().Relation;
        dualRelation.DatabaseId.Should().Be(createdSourceDatabase.Id);
        dualRelation.Type.Should().Be(RelationType.Dual);
        dualRelation.Should().BeOfType<DualPropertyRelation>();
    }

    private async Task<Database> CreateDatabaseWithAPageAsync(string databaseName)
    {
        var createDbRequest = new DatabasesCreateParameters
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
            Properties = new Dictionary<string, IPropertySchema>
            {
                { "Name", new TitlePropertySchema { Title = new Dictionary<string, object>() } },
            },
            Parent = new ParentPageInput { PageId = _page.Id }
        };

        var createdDatabase = await Client.Databases.CreateAsync(createDbRequest);

        var pagesCreateParameters = PagesCreateParametersBuilder
            .Create(new DatabaseParentInput { DatabaseId = createdDatabase.Id })
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
