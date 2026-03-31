using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class PageClientTests : IntegrationTestBase, IAsyncLifetime
{
    private Page _page = null!;
    private Database _database = null!;

    public async Task InitializeAsync()
    {
        // Create a page
        _page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(
                new PageParentRequest { PageId = ParentPageId }
            ).Build()
        );

        // Create a database
        var createDbRequest = new DatabasesCreateRequest
        {
            Title = new List<RichTextBaseInput>
            {
                new RichTextTextInput
                {
                    Text = new Text
                    {
                        Content = "Test List",
                        Link = null
                    }
                }
            },
            InitialDataSource = new InitialDataSourceRequest
            {
                Properties = new Dictionary<string, DataSourcePropertyConfigRequest>
                {
                    { "Name", new TitleDataSourcePropertyConfigRequest { Title = new Dictionary<string, object>() } },
                    {
                        "TestSelect",
                        new SelectDataSourcePropertyConfigRequest
                        {
                            Select = new SelectDataSourcePropertyConfigRequest.SelectOptions
                            {
                                Options = new List<SelectOptionRequest>
                                {
                                    new() { Name = "Red" },
                                    new() { Name = "Blue" }
                                }
                            }
                        }
                    },
                    { "Number", new NumberDataSourcePropertyConfigRequest { Number = new NumberDataSourcePropertyConfigRequest.NumberFormat { Format = "number" } } }
                }
            },
            Parent = new PageParentOfDatabaseRequest { PageId = _page.Id }
        };

        _database = await Client.Databases.CreateAsync(createDbRequest);
    }

    public async Task DisposeAsync()
    {
        await Client.Pages.UpdateAsync(_page.Id, new PagesUpdateParameters { InTrash = true });
    }

    [Fact]
    public async Task CreateAsync_CreatesANewPage()
    {
        var pagesCreateParameters = PagesCreateParametersBuilder
            .Create(new DataSourceParentRequest { DataSourceId = _database.DataSources.First().DataSourceId })
            .AddProperty("Name",
                new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextText { Text = new Text { Content = "Test Page Title" } }
                    }
                })
            .Build();

        var page = await Client.Pages.CreateAsync(pagesCreateParameters);

        page.Should().NotBeNull();

        page.Parent.Should().BeOfType<DatasourceParent>().Which
            .DataSourceId.Should().Be(_database.DataSources.First().DataSourceId);

        page.Properties.Should().ContainKey("Name");
        var pageProperty = page.Properties["Name"].Should().BeOfType<TitlePropertyValue>().Subject;

        var titleProperty
            = (ListPropertyItem)await Client.Pages.RetrievePagePropertyItemAsync(
                new RetrievePropertyItemParameters
                {
                    PageId = page.Id,
                    PropertyId = pageProperty.Id
                });

        titleProperty.Results.First().As<TitlePropertyItem>().Title.PlainText.Should().Be("Test Page Title");
    }

    [Fact]
    public async Task Bug_unable_to_create_page_with_select_property()
    {
        // Arrange
        var pagesCreateParameters = PagesCreateParametersBuilder
            .Create(new DataSourceParentRequest { DataSourceId = _database.DataSources.First().DataSourceId })
            .AddProperty("Name",
                new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextText { Text = new Text { Content = "Test Page Title" } }
                    }
                })
            .AddProperty("TestSelect",
                new SelectPropertyValue { Select = new SelectOption { Name = "Blue" } })
            .Build();

        // Act
        var page = await Client.Pages.CreateAsync(pagesCreateParameters);

        // Asserts
        page.Should().NotBeNull();

        page.Parent.Should().BeOfType<DatasourceParent>().Which
            .DataSourceId.Should().Be(_database.DataSources.First().DataSourceId);

        page.Properties.Should().ContainKey("Name");
        var titlePropertyValue = page.Properties["Name"].Should().BeOfType<TitlePropertyValue>().Subject;
        titlePropertyValue.Title.First().PlainText.Should().Be("Test Page Title");

        page.Properties.Should().ContainKey("TestSelect");
        var selectPropertyValue = page.Properties["TestSelect"].Should().BeOfType<SelectPropertyValue>().Subject;
        selectPropertyValue.Select.Name.Should().Be("Blue");
    }

    [Fact]
    public async Task Test_RetrievePagePropertyItemAsync()
    {
        // Arrange
        var pagesCreateParameters = PagesCreateParametersBuilder
            .Create(new DataSourceParentRequest { DataSourceId = _database.DataSources.First().DataSourceId })
            .AddProperty("Name",
                new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextText { Text = new Text { Content = "Test Page Title" } }
                    }
                })
            .Build();

        var page = await Client.Pages.CreateAsync(pagesCreateParameters);

        // Act
        var property = await Client.Pages.RetrievePagePropertyItemAsync(new RetrievePropertyItemParameters
        {
            PageId = page.Id,
            PropertyId = "title"
        });

        // Assert
        property.Should().NotBeNull();
        property.Should().BeOfType<ListPropertyItem>();

        var listProperty = (ListPropertyItem)property;

        listProperty.Type.Should().NotBeNull();

        listProperty.Results.Should().SatisfyRespectively(p =>
        {
            p.Should().BeOfType<TitlePropertyItem>();
            var titleProperty = (TitlePropertyItem)p;

            titleProperty.Title.PlainText.Should().Be("Test Page Title");
        });
    }

    [Fact]
    public async Task Test_UpdatePageProperty_with_date_as_null()
    {
        // Arrange

        // Add property Date property to database
        const string DatePropertyName = "Test Date Property";

        var updateDatabaseParameters = new UpdateDataSourceRequest
        {
            DataSourceId = _database.DataSources.First().DataSourceId,
            Properties = new Dictionary<string, IUpdatePropertyConfigurationRequest>
            {
                {
                    "Name",
                    new UpdatePropertyConfigurationRequest<TitleDataSourcePropertyConfigRequest> {
                        PropertyRequest = new TitleDataSourcePropertyConfigRequest { Title = new Dictionary<string, object>() }
                    }
                },
                {
                    "Test Date Property",
                    new UpdatePropertyConfigurationRequest<DateDataSourcePropertyConfigRequest>
                    {
                        Name = DatePropertyName,
                        PropertyRequest = new DateDataSourcePropertyConfigRequest
                        {
                            Date = new Dictionary<string, object>()
                        }
                    }
                }
            }
        };

        // Create a page with the property having a date
        var pagesCreateParameters = PagesCreateParametersBuilder
            .Create(new DataSourceParentRequest { DataSourceId = _database.DataSources.First().DataSourceId })
            .AddProperty("Name",
                new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextText { Text = new Text { Content = "Test Page Title" } }
                    }
                })
            .AddProperty(DatePropertyName,
                new DatePropertyValue
                {
                    Date = new Date
                    {
                        Start = DateTimeOffset.Parse("2024-06-26T00:00:00.000+01:00"),
                        End = DateTimeOffset.Parse("2025-12-08").Date,
                        IncludeTime = true
                    }
                })
            .Build();

        await Client.DataSources.UpdateAsync(updateDatabaseParameters);

        var page = await Client.Pages.CreateAsync(pagesCreateParameters);

        // Act
        var setDate = (DatePropertyItem)await Client.Pages.RetrievePagePropertyItemAsync(
            new RetrievePropertyItemParameters
            {
                PageId = page.Id,
                PropertyId = page.Properties[DatePropertyName].Id
            }
        );

        // Assert
        setDate?.Date?.Start.Should().Be(DateTimeOffset.Parse("2024-06-26T00:00:00.000+01:00"));
        setDate?.Date?.End.Should().Be(DateTimeOffset.Parse("2025-12-08").Date);

        var pageUpdateParameters = new PagesUpdateParameters
        {
            Properties = new Dictionary<string, PropertyValue>
            {
                { DatePropertyName, new DatePropertyValue { Date = null } }
            }
        };

        var updatedPage = await Client.Pages.UpdateAsync(page.Id, pageUpdateParameters);

        var verifyDate = (DatePropertyItem)await Client.Pages.RetrievePagePropertyItemAsync(
            new RetrievePropertyItemParameters
            {
                PageId = page.Id,
                PropertyId = updatedPage.Properties[DatePropertyName].Id
            }
        );

        verifyDate?.Date.Should().BeNull();
    }

    [Fact]
    public async Task Bug_Unable_To_Parse_NumberPropertyItem()
    {
        // Arrange
        var pagesCreateParameters = PagesCreateParametersBuilder
            .Create(new DataSourceParentRequest { DataSourceId = _database.DataSources.First().DataSourceId })
            .AddProperty("Name",
                new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextText { Text = new Text { Content = "Test Page Title" } }
                    }
                })
            .AddProperty("Number", new NumberPropertyValue { Number = 200.00 }).Build();

        // Act
        var page = await Client.Pages.CreateAsync(pagesCreateParameters);

        // Assert
        Assert.NotNull(page);
        var pageParent = Assert.IsType<DatasourceParent>(page.Parent);
        Assert.Equal(_database.DataSources.First().DataSourceId, pageParent.DataSourceId);

        var titleProperty = (ListPropertyItem)await Client.Pages.RetrievePagePropertyItemAsync(
            new RetrievePropertyItemParameters
            {
                PageId = page.Id,
                PropertyId = page.Properties["Name"].Id
            });

        Assert.Equal("Test Page Title", titleProperty.Results.First().As<TitlePropertyItem>().Title.PlainText);

        var numberProperty = (NumberPropertyItem)await Client.Pages.RetrievePagePropertyItemAsync(
            new RetrievePropertyItemParameters
            {
                PageId = page.Id,
                PropertyId = page.Properties["Number"].Id
            });

        Assert.Equal(200.00, numberProperty.Number);
    }

    [Fact]
    public async Task Bug_exception_when_attempting_to_set_select_property_to_nothing()
    {
        // Arrange
        var databaseCreateRequest = new DatabasesCreateRequest
        {
            Title = new List<RichTextBaseInput>
            {
                new RichTextTextInput { Text = new Text { Content = "Test Database" } }
            },
            Parent = new PageParentOfDatabaseRequest() { PageId = _page.Id },
            InitialDataSource = new InitialDataSourceRequest
            {
                Properties = new Dictionary<string, DataSourcePropertyConfigRequest>
                {
                    { "title", new TitleDataSourcePropertyConfigRequest { Title = new Dictionary<string, object>() } },
                    {
                        "Colors1",
                        new SelectDataSourcePropertyConfigRequest
                        {
                            Select = new SelectDataSourcePropertyConfigRequest.SelectOptions
                            {
                                Options = new List<SelectOptionRequest>
                                {
                                    new() { Name = "Red" },
                                    new() { Name = "Green" },
                                    new() { Name = "Blue" }
                                }
                            }
                        }
                    },
                    {
                        "Colors2",
                        new SelectDataSourcePropertyConfigRequest
                        {
                            Select = new SelectDataSourcePropertyConfigRequest.SelectOptions
                            {
                                Options = new List<SelectOptionRequest>
                                {
                                    new() { Name = "Red" },
                                    new() { Name = "Green" },
                                    new() { Name = "Blue" }
                                }
                            }
                        }
                    },
                }
            }
        };

        var database = await Client.Databases.CreateAsync(databaseCreateRequest);

        var pagesCreateParameters = PagesCreateParametersBuilder
            .Create(new DataSourceParentRequest { DataSourceId = database.DataSources.First().DataSourceId })
            .AddProperty("title",
                new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextTextInput { Text = new Text { Content = "Test" } }
                    }
                })
            .AddProperty("Colors1", new SelectPropertyValue { Select = new SelectOption { Name = "Red" } })
            .AddProperty("Colors2", new SelectPropertyValue { Select = new SelectOption { Name = "Green" } })
            .Build();

        // Act
        var page = await Client.Pages.CreateAsync(pagesCreateParameters);

        var updatePageRequest = new PagesUpdateParameters
        {
            Properties = new Dictionary<string, PropertyValue>
            {
                { "Colors1", new SelectPropertyValue { Select = new SelectOption { Name = "Blue" } } },
                { "Colors2", new SelectPropertyValue { Select = null } }
            }
        };

        var updatedPage = await Client.Pages.UpdateAsync(page.Id, updatePageRequest);

        // Assert
        page.Properties["Colors1"].As<SelectPropertyValue>().Select.Name.Should().Be("Red");
        page.Properties["Colors2"].As<SelectPropertyValue>().Select.Name.Should().Be("Green");

        updatedPage.Properties["Colors1"].As<SelectPropertyValue>().Select.Name.Should().Be("Blue");
        updatedPage.Properties["Colors2"].As<SelectPropertyValue>().Select.Should().BeNull();
    }

    [Fact]
    public async Task Verify_date_property_is_parsed_correctly_in_mention_object()
    {
        var pageRequest = PagesCreateParametersBuilder
            .Create(new DataSourceParentRequest { DataSourceId = _database.DataSources.First().DataSourceId })
            .AddProperty("Name",
                new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextMention()
                        {
                            Mention = new Mention()
                            {
                                Date = new Date()
                                {
                                    Start = DateTime.UtcNow
                                }
                            }
                        }
                    }
                })
            .Build();

        var page = await Client.Pages.CreateAsync(pageRequest);

        page.Should().NotBeNull();

        page.Parent.Should().BeOfType<DatasourceParent>().Which
            .DataSourceId.Should().Be(_database.DataSources.First().DataSourceId);

        page.Properties.Should().ContainKey("Name");
        var pageProperty = page.Properties["Name"].Should().BeOfType<TitlePropertyValue>().Subject;

        var titleProperty = (ListPropertyItem)await Client.Pages.RetrievePagePropertyItemAsync(
            new RetrievePropertyItemParameters
            {
                PageId = page.Id,
                PropertyId = pageProperty.Id
            });

        var mention = titleProperty.Results.First().As<TitlePropertyItem>().Title.As<RichTextMention>().Mention;
        mention.Date.Start.Should().NotBeNull();
        mention.Date.End.Should().BeNull();
    }
}
