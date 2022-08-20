using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests
{
    public class IPageClientTests
    {
        private readonly INotionClient _client;
        private readonly string _databaseId;

        public IPageClientTests()
        {
            var options = new ClientOptions
            {
                AuthToken = Environment.GetEnvironmentVariable("NOTION_AUTH_TOKEN")
            };

            _client = NotionClientFactory.Create(options);
            _databaseId = Environment.GetEnvironmentVariable("DATABASE_ID") ?? "f86f2262-0751-40f2-8f63-e3f7a3c39fcb";
        }

        [Fact]
        public async Task CreateAsync_CreatesANewPage()
        {
            PagesCreateParameters pagesCreateParameters = PagesCreateParametersBuilder.Create(new DatabaseParentInput
            {
                DatabaseId = _databaseId
            })
            .AddProperty("Name", new TitlePropertyValue
            {
                Title = new List<RichTextBase>
                {
                     new RichTextText
                     {
                         Text = new Text
                         {
                             Content = "Test Page Title"
                         }
                     }
                }
            })
            .Build();

            var page = await _client.Pages.CreateAsync(pagesCreateParameters);

            page.Should().NotBeNull();
            page.Parent.Should().BeOfType<DatabaseParent>().Which
                .DatabaseId.Should().Be(_databaseId);

            page.Properties.Should().ContainKey("Name");
            page.Properties["Name"].Should().BeOfType<TitlePropertyValue>().Which
                .Title.First().PlainText.Should().Be("Test Page Title");

            await _client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters
            {
                Archived = true
            });
        }

        [Fact]
        public async Task Bug_unable_to_create_page_with_select_property()
        {
            PagesCreateParameters pagesCreateParameters = PagesCreateParametersBuilder.Create(new DatabaseParentInput
            {
                DatabaseId = _databaseId
            })
            .AddProperty("Name", new TitlePropertyValue
            {
                Title = new List<RichTextBase>
                {
                     new RichTextText
                     {
                         Text = new Text
                         {
                             Content = "Test Page Title"
                         }
                     }
                }
            })
            .AddProperty("TestSelect", new SelectPropertyValue
            {
                Select = new SelectOption
                {
                    Id = "dfbfbe65-6f67-4876-9f75-699124334d06"
                }
            })
            .Build();

            var page = await _client.Pages.CreateAsync(pagesCreateParameters);

            page.Should().NotBeNull();
            page.Parent.Should().BeOfType<DatabaseParent>().Which
                .DatabaseId.Should().Be(_databaseId);

            page.Properties.Should().ContainKey("Name");
            page.Properties["Name"].Should().BeOfType<TitlePropertyValue>().Which
                .Title.First().PlainText.Should().Be("Test Page Title");

            await _client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters
            {
                Archived = true
            });
        }

        [Fact]
        public async Task Test_RetrievePagePropertyItemAsync()
        {
            PagesCreateParameters pagesCreateParameters = PagesCreateParametersBuilder.Create(new DatabaseParentInput
            {
                DatabaseId = _databaseId
            })
            .AddProperty("Name", new TitlePropertyValue
            {
                Title = new List<RichTextBase>
                {
                    new RichTextText
                    {
                        Text = new Text
                        {
                            Content = "Test Page Title"
                        }
                    }
                }
            })
            .Build();

            var page = await _client.Pages.CreateAsync(pagesCreateParameters);

            var property = await _client.Pages.RetrievePagePropertyItem(new RetrievePropertyItemParameters
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
            await _client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters
            {
                Archived = true
            });
        }

        [Fact]
        public async Task Test_UpdatePageProperty_with_date_as_null()
        {
            // setup - add property to db and create a page with the property having a date

            string datePropertyName = "Test Date Property";
            var updateDatabaseParameters = new DatabasesUpdateParameters();
            updateDatabaseParameters.Properties = new Dictionary<string, IUpdatePropertySchema>
            {
                { "Name", new TitleUpdatePropertySchema { Title = new Dictionary<string, object>() } },
                { "Test Date Property", new DateUpdatePropertySchema{ Date = new Dictionary<string, object>() } }
            };

            PagesCreateParameters pagesCreateParameters = PagesCreateParametersBuilder.Create(new DatabaseParentInput
            {
                DatabaseId = _databaseId
            })
            .AddProperty("Name", new TitlePropertyValue
            {
                Title = new List<RichTextBase>
                 {
                     new RichTextText
                     {
                         Text = new Text
                         {
                             Content = "Test Page Title"
                         }
                     }
                 }
            })
            .AddProperty(datePropertyName, new DatePropertyValue
            {
                Date = new Date()
                {
                    Start = Convert.ToDateTime("2020-12-08T12:00:00Z"),
                    End = Convert.ToDateTime("2025-12-08T12:00:00Z")
                }
            })
            .Build();

            var updatedDb = await _client.Databases.UpdateAsync(_databaseId, updateDatabaseParameters);

            var page = await _client.Pages.CreateAsync(pagesCreateParameters);

            var setDate = (DatePropertyItem)await _client.Pages.RetrievePagePropertyItem(new RetrievePropertyItemParameters
            {
                PageId = page.Id,
                PropertyId = page.Properties[datePropertyName].Id
            });

            setDate?.Date?.Start.Should().Be(Convert.ToDateTime("2020-12-08T12:00:00Z"));

            // verify
            IDictionary<string, PropertyValue> testProps = new Dictionary<string, PropertyValue>();
            testProps.Add(datePropertyName, new DatePropertyValue() { Date = null });

            var updatedPage = await _client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters
            {
                Properties = testProps
            });

            var verifyDate = (DatePropertyItem)await _client.Pages.RetrievePagePropertyItem(new RetrievePropertyItemParameters
            {
                PageId = page.Id,
                PropertyId = updatedPage.Properties[datePropertyName].Id
            });

            verifyDate?.Date.Should().BeNull();

            //cleanup
            await _client.Blocks.DeleteAsync(page.Id);
        }
    }
}
