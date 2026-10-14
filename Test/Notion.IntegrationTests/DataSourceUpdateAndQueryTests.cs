using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class DataSourceUpdateAndQueryTests : IntegrationTestBase, IAsyncLifetime
{
    private Page _page = null!;

    public async Task InitializeAsync()
    {
        _page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(new PageParentRequest { PageId = ParentPageId }).Build());
    }

    public async Task DisposeAsync()
    {
        await Client.Pages.UpdateAsync(_page.Id, new PagesUpdateParameters { InTrash = true });
    }

    [Fact]
    public async Task UpdateDataSource_CanRemoveProperty_WithNullValue()
    {
        var database = await CreateDatabaseWithAPageAsync("Test Data Source DB");
        var dataSource = await Client.DataSources.CreateAsync(new CreateDataSourceRequest
        {
            Parent = new DatabaseParentRequest { DatabaseId = database.Id },
            Properties = new Dictionary<string, DataSourcePropertyConfigRequest>
            {
                { "Name", new TitleDataSourcePropertyConfigRequest { Title = new Dictionary<string, object>() } },
                { "Notes", new RichTextDataSourcePropertyConfigRequest { RichText = new Dictionary<string, object>() } }
            },
            Title = new List<RichTextBaseInput>
            {
                new RichTextTextInput { Text = new Text { Content = "Removable property" } }
            }
        });
        dataSource.Properties.Should().ContainKey("Notes");

        var updated = await Client.DataSources.UpdateAsync(new UpdateDataSourceRequest
        {
            DataSourceId = dataSource.Id,
            Properties = new Dictionary<string, IUpdatePropertyConfigurationRequest> { { "Notes", null! } }
        });

        updated.Properties.Should().NotContainKey("Notes");
        updated.Properties.Should().ContainKey("Name");
    }

    [Fact]
    public async Task UpdateDataSource_WithoutInTrash_DoesNotChangeTrashStatus()
    {
        var database = await CreateDatabaseWithAPageAsync("Test Data Source DB");
        var dataSourceId = database.DataSources.First().DataSourceId;

        var updated = await Client.DataSources.UpdateAsync(new UpdateDataSourceRequest
        {
            DataSourceId = dataSourceId,
            Title = new List<RichTextBaseInput>
            {
                new RichTextTextInput { Text = new Text { Content = "Renamed only" } }
            }
        });

        updated.InTrash.Should().BeFalse();
    }

    [Fact]
    public async Task QueryDataSourceAsync_ReturnsCompleteRequestStatus()
    {
        var database = await CreateDatabaseWithAPageAsync("Test Data Source DB");
        var dataSourceId = database.DataSources.First().DataSourceId;

        var response = await Client.DataSources.QueryAsync(new QueryDataSourceRequest
        {
            DataSourceId = dataSourceId
        });

        // request_status is optional in the API; when present, a small data source must be complete.
        if (response.RequestStatus != null)
        {
            response.RequestStatus.IsIncomplete.Should().BeFalse();
        }
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
