using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class IPageClientTests : IntegrationTestBase
{
    [Fact]
    public async Task CreateAsync_CreatesANewPage()
    {
        var pagesCreateParameters = PagesCreateParametersBuilder
            .Create(new DatabaseParentInput { DatabaseId = ParentDatabaseId })
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
            .DatabaseId.Should().Be(ParentDatabaseId);

        page.Properties.Should().ContainKey("Name");
        var pageProperty = page.Properties["Name"].Should().BeOfType<PropertyValue>().Subject;

        var titleProperty
            = (ListPropertyItem)await Client.Pages.RetrievePagePropertyItemAsync(
                new RetrievePropertyItemParameters
                {
                    PageId = page.Id,
                    PropertyId = pageProperty.Id
                });

        titleProperty.Results.First().As<TitlePropertyItem>().Title.PlainText.Should().Be("Test Page Title");

        await Client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters { Archived = true });
    }

    [Fact]
    public async Task Bug_unable_to_create_page_with_select_property()
    {
        var pagesCreateParameters = PagesCreateParametersBuilder
            .Create(new DatabaseParentInput { DatabaseId = ParentDatabaseId })
            .AddProperty("Name",
                new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextText { Text = new Text { Content = "Test Page Title" } }
                    }
                })
            .AddProperty("TestSelect",
                new SelectPropertyValue { Select = new SelectOption { Id = "dfbfbe65-6f67-4876-9f75-699124334d06" } })
            .Build();

        var page = await Client.Pages.CreateAsync(pagesCreateParameters);

        page.Should().NotBeNull();

        page.Parent.Should().BeOfType<DatabaseParent>().Which
            .DatabaseId.Should().Be(ParentDatabaseId);

        page.Properties.Should().ContainKey("Name");
        var pageProperty = page.Properties["Name"].Should().BeOfType<PropertyValue>().Subject;

        var titleProperty
            = (ListPropertyItem)await Client.Pages.RetrievePagePropertyItemAsync(
                new RetrievePropertyItemParameters
                {
                    PageId = page.Id,
                    PropertyId = pageProperty.Id
                });

        titleProperty.Results.First().As<TitlePropertyItem>().Title.PlainText.Should().Be("Test Page Title");

        await Client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters { Archived = true });
    }

    [Fact]
    public async Task Test_RetrievePagePropertyItemAsync()
    {
        var pagesCreateParameters = PagesCreateParametersBuilder
            .Create(new DatabaseParentInput { DatabaseId = ParentDatabaseId })
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

        var property = await Client.Pages.RetrievePagePropertyItemAsync(new RetrievePropertyItemParameters
        {
            PageId = page.Id,
            PropertyId = "title"
        });

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

        // cleanup
        await Client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters { Archived = true });
    }

    [Fact]
    public async Task Test_UpdatePageProperty_with_date_as_null()
    {
        // setup - add property to db and create a page with the property having a date

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

        var pagesCreateParameters = PagesCreateParametersBuilder
            .Create(new DatabaseParentInput { DatabaseId = ParentDatabaseId })
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

        await Client.Databases.UpdateAsync(ParentDatabaseId, updateDatabaseParameters);

        var page = await Client.Pages.CreateAsync(pagesCreateParameters);

        var setDate = (DatePropertyItem)await Client.Pages.RetrievePagePropertyItemAsync(
            new RetrievePropertyItemParameters
            {
                PageId = page.Id,
                PropertyId = page.Properties[DatePropertyName].Id
            }
        );

        setDate?.Date?.Start.Should().Be(Convert.ToDateTime("2020-12-08T12:00:00Z"));

        // verify
        IDictionary<string, PropertyValue> testProps = new Dictionary<string, PropertyValue>();

        testProps.Add(DatePropertyName, new DatePropertyValue { Date = null });

        var updatedPage =
            await Client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters { Properties = testProps });

        var verifyDate = (DatePropertyItem)await Client.Pages.RetrievePagePropertyItemAsync(
            new RetrievePropertyItemParameters
            {
                PageId = page.Id,
                PropertyId = updatedPage.Properties[DatePropertyName].Id
            });

        verifyDate?.Date.Should().BeNull();

        //cleanup
        await Client.Blocks.DeleteAsync(page.Id);
    }

    [Fact]
    public async Task Bug_Unable_To_Parse_NumberPropertyItem()
    {
        // Arrange
        var pagesCreateParameters = PagesCreateParametersBuilder
            .Create(new DatabaseParentInput { DatabaseId = ParentDatabaseId }).AddProperty("Name",
                new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextText { Text = new Text { Content = "Test Page Title" } }
                    }
                }).AddProperty("Number", new NumberPropertyValue { Number = 200.00 }).Build();

        // Act
        var page = await Client.Pages.CreateAsync(pagesCreateParameters);

        // Assert
        Assert.NotNull(page);
        var pageParent = Assert.IsType<DatabaseParent>(page.Parent);
        Assert.Equal(ParentDatabaseId, pageParent.DatabaseId);

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

        await Client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters { Archived = true });
    }

    [Fact]
    public async Task Bug_exception_when_attempting_to_set_select_property_to_nothing()
    {
        // Arrange
        var databaseCreateRequest = new DatabasesCreateParameters
        {
            Title =
                new List<RichTextBaseInput>
                {
                    new RichTextTextInput() { Text = new Text { Content = "Test Database" } }
                },
            Parent = new ParentPageInput() { PageId = ParentPageId },
            Properties = new Dictionary<string, IPropertySchema>
            {
                {
                    "title", new TitlePropertySchema
                    {
                        Title = new Dictionary<string, object>()
                    }
                },
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

        await Client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters { Archived = true });
        await Client.Databases.UpdateAsync(database.Id, new DatabasesUpdateParameters { Archived = true });
    }
}
