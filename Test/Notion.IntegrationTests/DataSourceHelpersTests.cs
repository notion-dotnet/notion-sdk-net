using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class DataSourceHelpersTests : IntegrationTestBase, IAsyncLifetime
{
    private const int RowCount = 7;
    private Page _containerPage = null!;
    private string _dataSourceId = null!;

    public async Task InitializeAsync()
    {
        _containerPage = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(new PageParentRequest { PageId = ParentPageId }).Build());

        var database = await Client.Databases.CreateAsync(new DatabasesCreateRequest
        {
            Parent = new PageParentOfDatabaseRequest { PageId = _containerPage.Id },
            Title = new List<RichTextBaseInput>
            {
                new RichTextTextInput { Text = new Text { Content = "Data source helpers DB" } }
            },
            InitialDataSource = new InitialDataSourceRequest
            {
                Properties = new Dictionary<string, DataSourcePropertyConfigRequest>
                {
                    { "Name", new TitleDataSourcePropertyConfigRequest { Title = new Dictionary<string, object>() } }
                }
            }
        });

        _dataSourceId = database.DataSources.First().DataSourceId;

        for (var i = 1; i <= RowCount; i++)
        {
            await Client.Pages.CreateAsync(
                PagesCreateParametersBuilder
                    .Create(new DataSourceParentRequest { DataSourceId = _dataSourceId })
                    .AddProperty("Name", new TitlePropertyValue
                    {
                        Title = new List<RichTextBase>
                        {
                            new RichTextTextInput { Text = new Text { Content = $"Row {i}" } }
                        }
                    })
                    .Build());
        }
    }

    public async Task DisposeAsync()
    {
        await Client.Pages.UpdateAsync(_containerPage.Id, new PagesUpdateParameters { InTrash = true });
    }

    [Fact]
    public async Task CollectAllDataSourceRowsAsync_ReturnsEveryRowOnce()
    {
        var rows = await NotionDataSourceHelpers.CollectAllDataSourceRowsAsync(
            Client.DataSources,
            new QueryDataSourceRequest { DataSourceId = _dataSourceId, PageSize = 3 });

        rows.Should().HaveCount(RowCount);
        rows.Select(r => r.Id).Should().OnlyHaveUniqueItems();
        rows.Should().OnlyContain(r => NotionTypeGuards.IsFullPageOrDataSource(r));
    }

    [Fact]
    public async Task IterateAllDataSourceRowsAsync_RespectsTheCallersFilter()
    {
        var count = 0;

        await foreach (var _ in NotionDataSourceHelpers.IterateAllDataSourceRowsAsync(
                           Client.DataSources,
                           new QueryDataSourceRequest
                           {
                               DataSourceId = _dataSourceId,
                               Filter = new TitleFilter("Name", startsWith: "Row 1")
                           }))
        {
            count++;
        }

        count.Should().Be(1);
    }

    [Fact]
    public async Task CollectDataSourceTemplatesAsync_DoesNotThrowForADataSourceWithoutTemplates()
    {
        var templates = await NotionDataSourceHelpers.CollectDataSourceTemplatesAsync(
            Client.DataSources,
            new ListDataSourceTemplatesRequest { DataSourceId = _dataSourceId, PageSize = 2 });

        templates.Should().NotBeNull();
    }
}
