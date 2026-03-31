using System;
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
                new PageParentRequest { PageId = ParentPageId }
            ).Build()
        );
    }

    public async Task DisposeAsync()
    {
        await Client.Pages.UpdateAsync(_page.Id, new PagesUpdateParameters { InTrash = true });
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

    [Fact]
    public async Task Verify_mention_date_property_parsed_properly()
    {
        // Arrange
        var createDbRequest = new DatabasesCreateRequest
        {
            Title = new List<RichTextBaseInput>
            {
                new RichTextTextInput
                {
                    Text = new Text
                    {
                        Content = "Test DB",
                        Link = null
                    }
                },
                new RichTextMentionInput
                {
                    Mention = new MentionInput
                    {
                        Date = new Date
                        {
                            Start = DateTime.UtcNow,
                            End = DateTime.UtcNow.AddDays(1)
                        }
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

        // Act
        var createdDatabase = await Client.Databases.CreateAsync(createDbRequest);

        // Assert
        var mention = createdDatabase.Title.OfType<RichTextMention>().First().Mention;
        mention.Date.Start.Should().NotBeNull();
        mention.Date.End.Should().NotBeNull();
    }

    [Fact]
    public async Task UpdateDatabase()
    {
        // Arrange
        var createdDatabase = await CreateDatabaseWithAPageAsync("Initial DB Name");
        var updateRequest = new DatabasesUpdateRequest
        {
            DatabaseId = createdDatabase.Id,
            Title = new List<RichTextBaseInput>
            {
                new RichTextTextInput
                {
                    Text = new Text
                    {
                        Content = "Updated DB Name",
                        Link = null
                    }
                }
            }
        };

        // Act
        var updatedDatabase = await Client.Databases.UpdateAsync(updateRequest);

        // Assert
        updatedDatabase.Title.OfType<RichTextText>().First().Text.Content.Should().Be("Updated DB Name");
    }

    [Fact]
    public async Task RetrieveDatabase()
    {
        // Arrange
        var createdDatabase = await CreateDatabaseWithAPageAsync("Retrieve Test DB");

        // Act
        var retrievedDatabase = await Client.Databases.RetrieveAsync(createdDatabase.Id);

        // Assert
        retrievedDatabase.Id.Should().Be(createdDatabase.Id);
        retrievedDatabase.Title.OfType<RichTextText>().First().Text.Content.Should().Be("Retrieve Test DB");
        retrievedDatabase.DataSources.Should().ContainSingle();
    }
}