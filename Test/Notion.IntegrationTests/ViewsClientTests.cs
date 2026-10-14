using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class ViewsClientTests : IntegrationTestBase, IAsyncLifetime
{
    private Page _containerPage = null!;
    private Database _database = null!;
    private string _dataSourceId = null!;

    public async Task InitializeAsync()
    {
        _containerPage = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(new PageParentRequest { PageId = ParentPageId }).Build());

        _database = await Client.Databases.CreateAsync(new DatabasesCreateRequest
        {
            Parent = new PageParentOfDatabaseRequest { PageId = _containerPage.Id },
            Title = new List<RichTextBaseInput>
            {
                new RichTextTextInput { Text = new Text { Content = "Views DB" } }
            },
            InitialDataSource = new InitialDataSourceRequest
            {
                Properties = new Dictionary<string, DataSourcePropertyConfigRequest>
                {
                    { "Name", new TitleDataSourcePropertyConfigRequest { Title = new Dictionary<string, object>() } },
                    { "Done", new CheckboxDataSourcePropertyConfigRequest { Checkbox = new Dictionary<string, object>() } }
                }
            }
        });

        _dataSourceId = _database.DataSources.First().DataSourceId;
    }

    public async Task DisposeAsync()
    {
        await Client.Pages.UpdateAsync(_containerPage.Id, new PagesUpdateParameters { InTrash = true });
    }

    [Fact]
    public async Task CreateAsync_WithPosition_PlacesViewAfterAnotherView()
    {
        var first = await Client.Views.CreateAsync(new CreateViewRequest
        {
            DataSourceId = _dataSourceId,
            DatabaseId = _database.Id,
            Name = "First",
            Type = ViewType.Table,
            Position = ViewPositionRequest.Start()
        });

        var second = await Client.Views.CreateAsync(new CreateViewRequest
        {
            DataSourceId = _dataSourceId,
            DatabaseId = _database.Id,
            Name = "Second",
            Type = ViewType.Board,
            Position = ViewPositionRequest.AfterView(first.Id)
        });

        first.Name.Should().Be("First");
        second.Name.Should().Be("Second");

        var views = await Client.Views.ListAsync(new ListViewsRequest { DatabaseId = _database.Id });
        var ids = views.Results.Select(v => v.Id).ToList();
        ids.IndexOf(second.Id).Should().Be(ids.IndexOf(first.Id) + 1);
    }

    [Fact]
    public async Task CreateAsync_WithQuickFilters_ReturnsThemOnTheView()
    {
        var view = await Client.Views.CreateAsync(new CreateViewRequest
        {
            DataSourceId = _dataSourceId,
            DatabaseId = _database.Id,
            Name = "With quick filter",
            Type = ViewType.Table,
            QuickFilters = new Dictionary<string, object>
            {
                { "Done", new Dictionary<string, object> { { "checkbox", new Dictionary<string, object> { { "equals", true } } } } }
            }
        });

        view.QuickFilters.Should().ContainKey("Done");
    }

    [Fact]
    public async Task UpdateAsync_WithNullQuickFilter_RemovesIt()
    {
        var view = await Client.Views.CreateAsync(new CreateViewRequest
        {
            DataSourceId = _dataSourceId,
            DatabaseId = _database.Id,
            Name = "Quick filter to remove",
            Type = ViewType.Table,
            QuickFilters = new Dictionary<string, object>
            {
                { "Done", new Dictionary<string, object> { { "checkbox", new Dictionary<string, object> { { "equals", true } } } } }
            }
        });

        var updated = await Client.Views.UpdateAsync(new UpdateViewRequest
        {
            ViewId = view.Id, QuickFilters = new Dictionary<string, object> { { "Done", null! } }
        });

        (updated.QuickFilters == null || !updated.QuickFilters.ContainsKey("Done")).Should().BeTrue();
    }

    [Fact]
    public async Task CreateAsync_WithCreateDatabase_AddsLinkedDatabaseBlockToPage()
    {
        var view = await Client.Views.CreateAsync(new CreateViewRequest
        {
            DataSourceId = _dataSourceId,
            Name = "Linked view",
            Type = ViewType.Table,
            CreateDatabase = new CreateDatabaseForViewRequest(_containerPage.Id)
        });

        view.Id.Should().NotBeNullOrEmpty();
        view.Name.Should().Be("Linked view");
    }
}
