using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class PagePropertyItemTypesTests : IntegrationTestBase, IAsyncLifetime
{
    private Page _containerPage = null!;
    private Page _page = null!;

    public async Task InitializeAsync()
    {
        _containerPage = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(new PageParentRequest { PageId = ParentPageId }).Build());

        var database = await Client.Databases.CreateAsync(new DatabasesCreateRequest
        {
            Parent = new PageParentOfDatabaseRequest { PageId = _containerPage.Id },
            Title = new List<RichTextBaseInput>
            {
                new RichTextTextInput { Text = new Text { Content = "Property item types DB" } }
            },
            InitialDataSource = new InitialDataSourceRequest
            {
                Properties = new Dictionary<string, DataSourcePropertyConfigRequest>
                {
                    { "Name", new TitleDataSourcePropertyConfigRequest { Title = new Dictionary<string, object>() } },
                    {
                        "ID",
                        new UniqueIdDataSourcePropertyConfigRequest
                        {
                            UniqueId = new UniqueIdDataSourcePropertyConfigRequest.UniqueIdConfiguration { Prefix = "T" }
                        }
                    },
                    { "Run", new ButtonDataSourcePropertyConfigRequest { Button = new Dictionary<string, object>() } }
                }
            }
        });

        _page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder
                .Create(new DataSourceParentRequest { DataSourceId = database.DataSources.First().DataSourceId })
                .AddProperty("Name", new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextTextInput { Text = new Text { Content = "Item" } }
                    }
                })
                .Build());
    }

    public async Task DisposeAsync()
    {
        await Client.Pages.UpdateAsync(_containerPage.Id, new PagesUpdateParameters { InTrash = true });
    }

    [Fact]
    public async Task RetrievePagePropertyItemAsync_ForUniqueId_ReturnsUniqueIdPropertyItem()
    {
        var item = await Client.Pages.RetrievePagePropertyItemAsync(
            new RetrievePropertyItemParameters { PageId = _page.Id, PropertyId = _page.Properties["ID"].Id });

        var uniqueId = item.Should().BeOfType<UniqueIdPropertyItem>().Subject;
        uniqueId.UniqueId.Prefix.Should().Be("T");
        uniqueId.UniqueId.Number.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task RetrievePagePropertyItemAsync_ForButton_ReturnsButtonPropertyItem()
    {
        var item = await Client.Pages.RetrievePagePropertyItemAsync(
            new RetrievePropertyItemParameters { PageId = _page.Id, PropertyId = _page.Properties["Run"].Id });

        item.Should().BeOfType<ButtonPropertyItem>();
    }
}
