using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Notion.Client;
using Xunit;

namespace Notion.UnitTests;

public class FilterTests
{
    private readonly SerializerSettingsSource _settingsSource = new(new ClientOptions());

    private string SerializeFilter(Filter filter)
    {
        return JsonConvert.SerializeObject(filter, _settingsSource.GetSerializerSettings());
    }

    [Fact]
    public void CompoundFilterTest()
    {
        var selectFilter = new SelectFilter("A select", "Option");
        var relationFilter = new RelationFilter("Link", "subtask#1");
        var dateFilter = new DateFilter("Due", pastMonth: new Dictionary<string, object>());

        var filterGroup = new List<Filter>
        {
            relationFilter,
            selectFilter
        };

        var complexFiler = new CompoundFilter(
            and: new List<Filter>
            {
                dateFilter,
                new CompoundFilter(filterGroup)
            }
        );

        Assert.Equal(
            "{\"and\":[{\"date\":{\"past_month\":{}},\"property\":\"Due\"},"
            + "{\"or\":[{\"relation\":{\"contains\":\"subtask#1\"},\"property\":\"Link\"}," +
            "{\"select\":{\"equals\":\"Option\"},\"property\":\"A select\"}]}]}",
            SerializeFilter(complexFiler)
        );
    }

    [Fact]
    public void CheckboxFilterTest()
    {
        var filter = new CheckboxFilter("Property name", false);

        Assert.Equal(
            "{\"checkbox\":{\"equals\":false},\"property\":\"Property name\"}",
            SerializeFilter(filter)
        );
    }

    [Fact]
    public void DateFilterTest()
    {
        var filter = new DateFilter("When", onOrAfter: new DateTime(2042, 11, 29));

        Assert.Equal(
            "{\"date\":{\"on_or_after\":\"2042-11-29T00:00:00\"},\"property\":\"When\"}",
            SerializeFilter(filter)
        );
    }

    [Fact]
    public void FilesFilterTest()
    {
        var filter = new FilesFilter("Attachments", isNotEmpty: false);

        Assert.Equal(
            "{\"files\":{\"is_not_empty\":false},\"property\":\"Attachments\"}",
            SerializeFilter(filter)
        );
    }

    [Fact]
    public void FormulaFilterTest()
    {
        var filter = new FormulaFilter(
            "Some",
            number: new NumberFilter.Condition(isEmpty: true)
        );

        Assert.Equal(
            "{\"formula\":{\"number\":{\"is_empty\":true}},\"property\":\"Some\"}",
            SerializeFilter(filter)
        );
    }

    [Fact]
    public void MultiSelectFilterTest()
    {
        var filter = new MultiSelectFilter("category 1", doesNotContain: "tag");

        Assert.Equal(
            "{\"multi_select\":{\"does_not_contain\":\"tag\"},\"property\":\"category 1\"}",
            SerializeFilter(filter)
        );
    }

    [Fact(Skip = "Not sure if integer should be serialized as a number with decimals")]
    public void NumberFilterTest()
    {
        var filter = new NumberFilter("sum", greaterThanOrEqualTo: -54);

        Assert.Equal(
            "{\"number\":{\"greater_than_or_equal_to\":-54.0},\"property\":\"sum\"}",
            SerializeFilter(filter)
        );
    }

    [Fact]
    public void PeopleFilter()
    {
        var filter = new PeopleFilter("assignee PM", doesNotContain: "some-uuid");

        Assert.Equal(
            "{\"people\":{\"does_not_contain\":\"some-uuid\"},\"property\":\"assignee PM\"}",
            SerializeFilter(filter)
        );
    }

    [Fact]
    public void RichTextFilterTest()
    {
        var filter = new RichTextFilter("Some property", doesNotEqual: "Example text");

        Assert.Equal(
            "{\"rich_text\":{\"does_not_equal\":\"Example text\"},\"property\":\"Some property\"}",
            SerializeFilter(filter)
        );
    }

    private class SerializerSettingsSource : RestClient
    {
        public SerializerSettingsSource(ClientOptions options) : base(options)
        {
        }

        public JsonSerializerSettings GetSerializerSettings()
        {
            return DefaultSerializerSettings;
        }
    }
}
