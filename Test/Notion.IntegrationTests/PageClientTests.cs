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
                new ParentPageInput { PageId = ParentPageId }
            ).Build()
        );

        // Create a database
        var createDbRequest = new DatabasesCreateParameters
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
            Properties = new Dictionary<string, IPropertySchema>
            {
                { "Name", new TitlePropertySchema { Title = new Dictionary<string, object>() } },
                {
                    "TestSelect",
                    new SelectPropertySchema
                    {
                        Select = new OptionWrapper<SelectOptionSchema>
                        {
                            Options = new List<SelectOptionSchema>
                            {
                                new() { Name = "Red" },
                                new() { Name = "Blue" }
                            }
                        }
                    }
                },
                { "Number", new NumberPropertySchema { Number = new Number { Format = "number" } } }
            },
            Parent = new ParentPageInput { PageId = _page.Id }
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
            .Create(new DatabaseParentInput { DatabaseId = _database.Id })
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

        page.Parent.Should().BeOfType<DatabaseParent>().Which
            .DatabaseId.Should().Be(_database.Id);

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
            .Create(new DatabaseParentInput { DatabaseId = _database.Id })
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

        page.Parent.Should().BeOfType<DatabaseParent>().Which
            .DatabaseId.Should().Be(_database.Id);

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
            .Create(new DatabaseParentInput { DatabaseId = _database.Id })
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

        var updateDatabaseParameters = new DatabasesUpdateParameters
        {
            Properties = new Dictionary<string, IUpdatePropertySchema>
            {
                { "Name", new TitleUpdatePropertySchema { Title = new Dictionary<string, object>() } },
                {
                    "Test Date Property",
                    new DateUpdatePropertySchema { Date = new Dictionary<string, object>() }
                }
            }
        };

        // Create a page with the property having a date
        var pagesCreateParameters = PagesCreateParametersBuilder
            .Create(new DatabaseParentInput { DatabaseId = _database.Id })
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
                        Start = Convert.ToDateTime("2020-12-08T12:00:00Z"),
                        End = Convert.ToDateTime("2025-12-08T12:00:00Z")
                    }
                })
            .Build();

        await Client.Databases.UpdateAsync(_database.Id, updateDatabaseParameters);

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
        setDate?.Date?.Start.Should().Be(Convert.ToDateTime("2020-12-08T12:00:00Z"));

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
            .Create(new DatabaseParentInput { DatabaseId = _database.Id })
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
        var pageParent = Assert.IsType<DatabaseParent>(page.Parent);
        Assert.Equal(_database.Id, pageParent.DatabaseId);

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
        var databaseCreateRequest = new DatabasesCreateParameters
        {
            Title =
                new List<RichTextBaseInput> { new RichTextTextInput { Text = new Text { Content = "Test Database" } } },
            Parent = new ParentPageInput() { PageId = _page.Id },
            Properties = new Dictionary<string, IPropertySchema>
            {
                { "title", new TitlePropertySchema { Title = new Dictionary<string, object>() } },
                {
                    "Colors1",
                    new SelectPropertySchema
                    {
                        Select = new OptionWrapper<SelectOptionSchema>
                        {
                            Options = new List<SelectOptionSchema>
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
                    new SelectPropertySchema
                    {
                        Select = new OptionWrapper<SelectOptionSchema>
                        {
                            Options = new List<SelectOptionSchema>
                            {
                                new() { Name = "Red" },
                                new() { Name = "Green" },
                                new() { Name = "Blue" }
                            }
                        }
                    }
                },
            }
        };

        var database = await Client.Databases.CreateAsync(databaseCreateRequest);

        var pagesCreateParameters = PagesCreateParametersBuilder
            .Create(new DatabaseParentInput { DatabaseId = database.Id })
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
}
