using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class PageMoveTests : IntegrationTestBase, IAsyncLifetime
{
    private readonly List<string> _createdPageIds = new();

    public Task InitializeAsync() => Task.CompletedTask;

    public async Task DisposeAsync()
    {
        foreach (var id in _createdPageIds)
        {
            await Client.Pages.UpdateAsync(id, new PagesUpdateParameters { InTrash = true });
        }
    }

    [Fact]
    public async Task Move_Page_To_Another_Page()
    {
        var newParent = await CreatePageAsync(ParentPageId, "Move target page");
        var page = await CreatePageAsync(ParentPageId, "Page to move");

        var moved = await Client.Pages.MoveAsync(new MovePageRequest
        {
            PageId = page.Id, Parent = MovePageParent.ToPage(newParent.Id)
        });

        moved.Id.Should().Be(page.Id);
        moved.Parent.Should().BeOfType<PageParent>().Which.PageId.Should().Be(newParent.Id);
    }

    [Fact]
    public async Task Move_Page_To_Data_Source()
    {
        var database = await Client.Databases.RetrieveAsync(ParentDatabaseId);
        var dataSourceId = database.DataSources.First().DataSourceId;
        var page = await CreatePageAsync(ParentPageId, "Page to move into data source");

        var moved = await Client.Pages.MoveAsync(new MovePageRequest
        {
            PageId = page.Id, Parent = MovePageParent.ToDataSource(dataSourceId)
        });

        moved.Id.Should().Be(page.Id);
        moved.Parent.Should().BeOfType<DatasourceParent>().Which.DataSourceId.Should().Be(dataSourceId);
    }

    private async Task<Page> CreatePageAsync(string parentPageId, string title)
    {
        var page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder
                .Create(new PageParentRequest { PageId = parentPageId })
                .AddProperty("title", new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextTextInput { Text = new Text { Content = title } }
                    }
                })
                .Build());

        _createdPageIds.Add(page.Id);
        return page;
    }
}
