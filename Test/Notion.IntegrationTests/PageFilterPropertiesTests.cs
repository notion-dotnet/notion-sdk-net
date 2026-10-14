using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class PageFilterPropertiesTests : IntegrationTestBase, IAsyncLifetime
{
    private Page _containerPage = null!;
    private string _dataSourceId = null!;
    private string _nameId = null!;
    private string _notesId = null!;

    public async Task InitializeAsync()
    {
        _containerPage = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(new PageParentRequest { PageId = ParentPageId }).Build());

        var database = await Client.Databases.CreateAsync(new DatabasesCreateRequest
        {
            Parent = new PageParentOfDatabaseRequest { PageId = _containerPage.Id },
            Title = new List<RichTextBaseInput>
            {
                new RichTextTextInput { Text = new Text { Content = "filter_properties DB" } }
            },
            InitialDataSource = new InitialDataSourceRequest
            {
                Properties = new Dictionary<string, DataSourcePropertyConfigRequest>
                {
                    { "Name", new TitleDataSourcePropertyConfigRequest { Title = new Dictionary<string, object>() } },
                    { "Notes", new RichTextDataSourcePropertyConfigRequest { RichText = new Dictionary<string, object>() } }
                }
            }
        });

        _dataSourceId = database.DataSources.First().DataSourceId;
        var dataSource = await Client.DataSources.RetrieveAsync(
            new RetrieveDataSourceRequest { DataSourceId = _dataSourceId });
        _nameId = dataSource.Properties["Name"].Id;
        _notesId = dataSource.Properties["Notes"].Id;
    }

    public async Task DisposeAsync()
    {
        await Client.Pages.UpdateAsync(_containerPage.Id, new PagesUpdateParameters { InTrash = true });
    }

    [Fact]
    public async Task RetrieveAsync_WithFilterProperties_ReturnsOnlyRequestedProperties()
    {
        var page = await CreatePageInDataSourceAsync(filterProperties: null);
        page.Properties.Should().ContainKeys("Name", "Notes");

        var filtered = await Client.Pages.RetrieveAsync(page.Id, new[] { _nameId });

        filtered.Properties.Should().ContainKey("Name");
        filtered.Properties.Should().NotContainKey("Notes");
    }

    [Fact]
    public async Task CreateAsync_WithFilterProperties_ReturnsOnlyRequestedProperties()
    {
        var page = await CreatePageInDataSourceAsync(filterProperties: new[] { _notesId });

        page.Properties.Should().ContainKey("Notes");
        page.Properties.Should().NotContainKey("Name");
    }

    [Fact]
    public async Task UpdateAsync_WithFilterProperties_ReturnsOnlyRequestedProperties()
    {
        var page = await CreatePageInDataSourceAsync(filterProperties: null);

        var updated = await Client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters
        {
            Properties = new Dictionary<string, PropertyValue>
            {
                {
                    "Notes",
                    new RichTextPropertyValue
                    {
                        RichText = new List<RichTextBase>
                        {
                            new RichTextText { Text = new Text { Content = "updated" } }
                        }
                    }
                }
            },
            FilterProperties = new[] { _nameId }
        });

        updated.Properties.Should().ContainKey("Name");
        updated.Properties.Should().NotContainKey("Notes");
    }

    [Fact]
    public async Task UpdateAsync_WithoutInTrash_DoesNotUntrashOrTrashPage()
    {
        var page = await CreatePageInDataSourceAsync(filterProperties: null);

        var updated = await Client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters
        {
            Properties = new Dictionary<string, PropertyValue>
            {
                {
                    "Name",
                    new TitlePropertyValue
                    {
                        Title = new List<RichTextBase>
                        {
                            new RichTextText { Text = new Text { Content = "renamed" } }
                        }
                    }
                }
            }
        });

        updated.InTrash.Should().BeFalse();
    }

    private async Task<Page> CreatePageInDataSourceAsync(IEnumerable<string>? filterProperties)
    {
        var parameters = PagesCreateParametersBuilder
            .Create(new DataSourceParentRequest { DataSourceId = _dataSourceId })
            .AddProperty("Name", new TitlePropertyValue
            {
                Title = new List<RichTextBase>
                {
                    new RichTextTextInput { Text = new Text { Content = "A page" } }
                }
            })
            .AddProperty("Notes", new RichTextPropertyValue
            {
                RichText = new List<RichTextBase>
                {
                    new RichTextTextInput { Text = new Text { Content = "some notes" } }
                }
            })
            .Build();
        parameters.FilterProperties = filterProperties;

        return await Client.Pages.CreateAsync(parameters);
    }
}
