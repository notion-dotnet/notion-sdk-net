using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using WireMock.ResponseBuilders;
using Xunit;

namespace Notion.UnitTests;

public class DatabasesClientTests : ApiTestBase
{
    private readonly IDatabasesClient _client;
    private readonly IPagesClient _pagesClient;

    public DatabasesClientTests()
    {
        _client = new DatabasesClient(new RestClient(ClientOptions));
        _pagesClient = new PagesClient(new RestClient(ClientOptions));
    }

    [Fact]
    public async Task QueryAsync()
    {
        var databaseId = "f0212efc-caf6-4afc-87f6-1c06f1dfc8a1";
        var path = ApiEndpoints.DatabasesApiUrls.Query(databaseId);
        var jsonData = await File.ReadAllTextAsync("data/databases/DatabasesQueryResponse.json");

        Server.Given(CreatePostRequestBuilder(path))
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

        var databasesQueryParams = new DatabasesQueryParameters
        {
            Filter = new CompoundFilter
            {
                Or = new List<Filter>
                {
                    new CheckboxFilter(
                        "In stock",
                        true
                    ),
                    new NumberFilter(
                        "Cost of next trip",
                        greaterThanOrEqualTo: 2
                    )
                }
            },
            Sorts = new List<Sort>
            {
                new()
                {
                    Property = "Last ordered",
                    Direction = Direction.Ascending
                }
            }
        };

        var pagesPaginatedList = await _client.QueryAsync(databaseId, databasesQueryParams);

        pagesPaginatedList.Results.Should().ContainSingle();

        foreach (var iWikiDatabase in pagesPaginatedList.Results)
        {
            var page = (Page)iWikiDatabase;
            page.Parent.Should().BeAssignableTo<IPageParent>();
            page.Object.Should().Be(ObjectType.Page);
        }
    }

    [Fact]
    public async Task RetrieveDatabaseAsync()
    {
        var databaseId = "f0212efc-caf6-4afc-87f6-1c06f1dfc8a1";
        var path = ApiEndpoints.DatabasesApiUrls.Retrieve(databaseId);
        var jsonData = await File.ReadAllTextAsync("data/databases/DatabaseRetrieveResponse.json");

        Server.Given(CreateGetRequestBuilder(path))
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

        var database = await _client.RetrieveAsync(databaseId);

        database.Parent.Type.Should().Be(ParentType.PageId);
        database.Parent.Should().BeOfType<PageParent>();
        ((PageParent)database.Parent).PageId.Should().Be("649089db-8984-4051-98fb-a03593b852d8");

        foreach (var property in database.Properties)
        {
            property.Key.Should().Be(property.Value.Name);
        }

        HelperAsserts.IPageIconAsserts(database.Icon);
        HelperAsserts.FileObjectAsserts(database.Cover);
    }

    [Fact]
    public async Task DatabasePropertyObjectContainNameProperty()
    {
        var databaseId = "f0212efc-caf6-4afc-87f6-1c06f1dfc8a1";
        var path = ApiEndpoints.DatabasesApiUrls.Retrieve(databaseId);
        var jsonData = await File.ReadAllTextAsync("data/databases/DatabasePropertyObjectContainNameProperty.json");

        Server.Given(CreateGetRequestBuilder(path))
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

        var database = await _client.RetrieveAsync(databaseId);

        foreach (var property in database.Properties)
        {
            property.Key.Should().Be(property.Value.Name);
        }
    }

    [Fact]
    public async Task DatabasePropertyObjectContainRelationProperty()
    {
        var databaseId = "f0212efc-caf6-4afc-87f6-1c06f1dfc8a1";
        var path = ApiEndpoints.DatabasesApiUrls.Retrieve(databaseId);
        var jsonData = await File.ReadAllTextAsync("data/databases/DatabasePropertyObjectContainRelation.json");

        Server.Given(CreateGetRequestBuilder(path))
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

        var database = await _client.RetrieveAsync(databaseId);

        database.Properties.Should().ContainKey("Property").WhichValue.Should().BeEquivalentTo(
            new RelationProperty
            {
                Id = "zDGa",
                Name = "Property",
                Relation = new DualPropertyRelation
                {
                    DatabaseId = "f86f2262-0751-40f2-8f63-e3f7a3c39fcb",
                    DualProperty = new DualPropertyRelation.Data
                    {
                        SyncedPropertyName = "Related to sample table (Property)",
                        SyncedPropertyId = "VQ}{"
                    }
                }
            });
    }

    [Fact]
    public async Task DatabasePropertyObjectContainParentProperty()
    {
        var databaseId = "f0212efc-caf6-4afc-87f6-1c06f1dfc8a1";
        var path = ApiEndpoints.DatabasesApiUrls.Retrieve(databaseId);
        var jsonData = await File.ReadAllTextAsync("data/databases/DatabasePropertyObjectContainParentProperty.json");

        Server.Given(CreateGetRequestBuilder(path))
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

        var database = await _client.RetrieveAsync(databaseId);

        database.Parent.Type.Should().Be(ParentType.PageId);
        database.Parent.Should().BeOfType<PageParent>();
        ((PageParent)database.Parent).PageId.Should().Be("649089db-8984-4051-98fb-a03593b852d8");
    }

    [Fact]
    public async Task CreateDatabaseAsync()
    {
        var pageId = "533578e3-edf1-4c0a-91a9-da6b09bac3ee";
        var path = ApiEndpoints.DatabasesApiUrls.Create;
        var jsonData = await File.ReadAllTextAsync("data/databases/CreateDatabaseResponse.json");

        Server.Given(CreatePostRequestBuilder(path))
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

        var createDatabaseParameters = new DatabasesCreateParameters
        {
            Parent = new ParentPageInput { PageId = pageId },
            Title = new List<RichTextBaseInput>
            {
                new RichTextTextInput
                {
                    Text = new Text
                    {
                        Content = "Grocery List",
                        Link = null
                    }
                }
            },
            Properties = new Dictionary<string, IPropertySchema>
            {
                { "Name", new TitlePropertySchema { Title = new Dictionary<string, object>() } },
                { "Price", new NumberPropertySchema { Number = new Number { Format = "dollar" } } },
                {
                    "Food group",
                    new SelectPropertySchema
                    {
                        Select = new OptionWrapper<SelectOptionSchema>
                        {
                            Options = new List<SelectOptionSchema>
                            {
                                new()
                                {
                                    Color = Color.Green,
                                    Name = "🥦Vegetable"
                                },
                                new()
                                {
                                    Color = Color.Red,
                                    Name = "🍎Fruit"
                                },
                                new()
                                {
                                    Color = Color.Yellow,
                                    Name = "💪Protein"
                                }
                            }
                        }
                    }
                },
                { "Last ordered", new DatePropertySchema { Date = new Dictionary<string, object>() } }
            }
        };

        var database = await _client.CreateAsync(createDatabaseParameters);

        database.Parent.Type.Should().Be(ParentType.PageId);
        database.Parent.Should().BeOfType<PageParent>();
        ((PageParent)database.Parent).PageId.Should().Be(pageId);

        database.Properties.Should().HaveCount(4);

        var selectOptions = (SelectProperty)database.Properties["Food group"];
        selectOptions.Name.Should().Be("Food group");

        selectOptions.Select.Options.Should().SatisfyRespectively(
            option =>
            {
                option.Name.Should().Be("🥦Vegetable");
                option.Color.Should().Be(Color.Green);
            },
            option =>
            {
                option.Name.Should().Be("🍎Fruit");
                option.Color.Should().Be(Color.Red);
            },
            option =>
            {
                option.Name.Should().Be("💪Protein");
                option.Color.Should().Be(Color.Yellow);
            }
        );
    }

    [Fact]
    public async Task UpdateDatabaseAsync()
    {
        var databaseId = "1e9eee34-9c5c-4fe6-a4e1-8244eb141ed8";
        var path = ApiEndpoints.DatabasesApiUrls.Update(databaseId);
        var jsonData = await File.ReadAllTextAsync("data/databases/UpdateDatabaseResponse.json");

        Server.Given(CreatePatchRequestBuilder(path))
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

        var updateDatabaseParameters = new DatabasesUpdateParameters
        {
            Title =
                new List<RichTextBaseInput>
                {
                    new RichTextTextInput
                    {
                        Text = new Text
                        {
                            Content = "Grocery List New",
                            Link = null
                        }
                    }
                },
            Properties = new Dictionary<string, IUpdatePropertySchema>
            {
                { "Name", new TitleUpdatePropertySchema { Title = new Dictionary<string, object>() } },
                { "Price", new NumberUpdatePropertySchema { Number = new Number { Format = "yen" } } },
                {
                    "Food group",
                    new SelectUpdatePropertySchema
                    {
                        Select = new OptionWrapper<SelectOption>
                        {
                            Options = new List<SelectOption>
                            {
                                new()
                                {
                                    Color = Color.Green,
                                    Name = "🥦Vegetables"
                                },
                                new()
                                {
                                    Color = Color.Red,
                                    Name = "🍎Fruit"
                                },
                                new()
                                {
                                    Color = Color.Yellow,
                                    Name = "💪Protein"
                                }
                            }
                        }
                    }
                },
                { "Last ordered", new DateUpdatePropertySchema { Date = new Dictionary<string, object>() } }
            }
        };

        var database = await _client.UpdateAsync(databaseId, updateDatabaseParameters);

        database.Parent.Type.Should().Be(ParentType.PageId);
        database.Parent.Should().BeOfType<PageParent>();
        ((PageParent)database.Parent).PageId.Should().Be("533578e3-edf1-4c0a-91a9-da6b09bac3ee");

        database.Properties.Should().HaveCount(4);

        database.Title.Should().ContainSingle();

        database.Title.Should().SatisfyRespectively(
            title =>
            {
                title.Should().BeAssignableTo<RichTextText>();
                ((RichTextText)title).Text.Content.Should().Be("Grocery List New");
            }
        );

        var selectOptions = (SelectProperty)database.Properties["Food group"];
        selectOptions.Name.Should().Be("Food group");

        selectOptions.Select.Options.Should().SatisfyRespectively(
            option =>
            {
                option.Name.Should().Be("🥦Vegetables");
                option.Color.Should().Be(Color.Green);
            },
            option =>
            {
                option.Name.Should().Be("🍎Fruit");
                option.Color.Should().Be(Color.Red);
            },
            option =>
            {
                option.Name.Should().Be("💪Protein");
                option.Color.Should().Be(Color.Yellow);
            }
        );

        var price = (NumberProperty)database.Properties["Price"];
        price.Number.Format.Should().Be("yen");
    }

    [Fact]
    public async Task FormulaPropertyCanBeSetWhenCreatingDatabase()
    {
        var pageId = "98ad959b-2b6a-4774-80ee-00246fb0ea9b";
        var path = ApiEndpoints.DatabasesApiUrls.Create;

        var jsonData
            = await File.ReadAllTextAsync("data/databases/FormulaPropertyCanBeSetWhenCreatingDatabaseResponse.json");

        Server.Given(CreatePostRequestBuilder(path))
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

        var createDatabaseParameters = new DatabasesCreateParameters
        {
            Parent = new ParentPageInput { PageId = pageId },
            Title = new List<RichTextBaseInput>
            {
                new RichTextTextInput
                {
                    Text = new Text
                    {
                        Content = "Grocery List",
                        Link = null
                    }
                }
            },
            Properties = new Dictionary<string, IPropertySchema>
            {
                {
                    "Cost of next trip",
                    new FormulaPropertySchema
                    {
                        Formula = new Formula { Expression = "if(prop(\"In stock\"), 0, prop(\"Price\"))" }
                    }
                },
                { "Price", new NumberPropertySchema { Number = new Number { Format = "dollar" } } }
            }
        };

        var database = await _client.CreateAsync(createDatabaseParameters);

        database.Parent.Type.Should().Be(ParentType.PageId);
        database.Parent.Should().BeOfType<PageParent>();
        ((PageParent)database.Parent).PageId.Should().Be(pageId);

        database.Properties.Should().HaveCount(2);

        var formulaProperty = (FormulaProperty)database.Properties["Cost of next trip"];
        formulaProperty.Formula.Expression.Should().Be("if(prop(\"In stock\"), 0, prop(\"Price\"))");
    }

    [Fact]
    public async Task Fix123_QueryAsync_DateFormulaValue_Returns_Null()
    {
        var databaseId = "f86f2262-0751-40f2-8f63-e3f7a3c39fcb";
        var path = ApiEndpoints.DatabasesApiUrls.Query(databaseId);

        var jsonData
            = await File.ReadAllTextAsync("data/databases/Fix123QueryAsyncDateFormulaValueReturnsNullResponse.json");

        Server.Given(CreatePostRequestBuilder(path))
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

        var databasesQueryParams = new DatabasesQueryParameters
        {
            Filter = new CompoundFilter
            {
                Or = new List<Filter>
                {
                    new CheckboxFilter(
                        "In stock",
                        true
                    ),
                    new NumberFilter(
                        "Cost of next trip",
                        greaterThanOrEqualTo: 2
                    )
                }
            },
            Sorts = new List<Sort>
            {
                new()
                {
                    Property = "Last ordered",
                    Direction = Direction.Ascending
                }
            }
        };

        var pagesPaginatedList = await _client.QueryAsync(databaseId, databasesQueryParams);

        pagesPaginatedList.Results.Should().ContainSingle();

        foreach (var iWikiDatabase in pagesPaginatedList.Results)
        {
            var page = (Page)iWikiDatabase;
            page.Parent.Should().BeAssignableTo<IPageParent>();
            page.Object.Should().Be(ObjectType.Page);

            Server.Given(CreateGetRequestBuilder(
                    ApiEndpoints.PagesApiUrls.RetrievePropertyItem(page.Id, page.Properties["FormulaProp"].Id)))
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithBody(
                            "{\"object\":\"property_item\",\"id\":\"JwY^\",\"type\":\"formula\",\"formula\":{\"type\":\"date\",\"date\":{\"start\":\"2021-06-28\",\"end\":null}}}")
                );

            var formulaPropertyValue = (FormulaPropertyItem)await _pagesClient.RetrievePagePropertyItemAsync(
                new RetrievePropertyItemParameters
                {
                    PageId = page.Id,
                    PropertyId = page.Properties["FormulaProp"].Id
                });

            //var formulaPropertyValue = (FormulaPropertyValue)page.Properties["FormulaProp"];
            formulaPropertyValue.Formula.Date.Start.Should().Be(DateTime.Parse("2021-06-28"));
            formulaPropertyValue.Formula.Date.End.Should().BeNull();
        }
    }
}
