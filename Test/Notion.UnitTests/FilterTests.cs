using Newtonsoft.Json;
using Notion.Client;
using System;
using System.Collections.Generic;
using Xunit;

namespace Notion.UnitTests
{
    public class SerializerSettingsSource : RestClient
    {
        public SerializerSettingsSource(ClientOptions options) : base(options)
        {

        }

        public JsonSerializerSettings GetSerializerSettings()
        {
            return defaultSerializerSettings;
        }

    }
    public class FilterTests
    {
        private SerializerSettingsSource _settingsSource = new SerializerSettingsSource(new ClientOptions());

        private string SerializeFilter(Filter filter)
        {
            return JsonConvert.SerializeObject(filter, _settingsSource.GetSerializerSettings());
        }

        [Fact]
        public void CompoundFilterTest()
        {
            var selectFilter = new SelectFilter
            {
                Property = "A select",
                Select = new SelectFilterCondition
                {
                    Equal = "Option"
                }
            };
            var relationFilter = new RelationFilter
            {
                Property = "Link",
                Relation = new RelationFilterCondition
                {
                    Contains = "subtask#1"
                }
            };
            var dateFilter = new DateFilter
            {
                Property = "Due",
                Date = new DateFilterCondition
                {
                    PastMonth = new Dictionary<string, object>()
                }
            };

            var complexFiler = new CompoundFilter
            {
                And = new List<Filter> {
                    dateFilter,
                    new CompoundFilter {
                        Or = new List<Filter> {relationFilter, selectFilter}
                    }
                }
            };

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
            var filter = new CheckboxFilter
            {
                Property = "Property name",
                Checkbox = new CheckboxFilterCondition
                {
                    Equal = false
                },
            };

            Assert.Equal(
                "{\"checkbox\":{\"equals\":false},\"property\":\"Property name\"}",
                SerializeFilter(filter)
            );
        }

        [Fact]
        public void DateFilterTest()
        {
            var filter = new DateFilter
            {
                Property = "When",
                Date = new DateFilterCondition
                {
                    OnOrAfter = new DateTime(2042, 11, 29)
                },
            };

            Assert.Equal(
                "{\"date\":{\"on_or_after\":\"2042-11-29T00:00:00\"},\"property\":\"When\"}",
                SerializeFilter(filter)
            );
        }

        [Fact]
        public void FilesFilterTest()
        {
            var filter = new FilesFilter
            {
                Property = "Attachments",
                Files = new FilesFilterCondition
                {
                    IsNotEmpty = false
                },
            };

            Assert.Equal(
                "{\"files\":{\"is_not_empty\":false},\"property\":\"Attachments\"}",
                SerializeFilter(filter)
            );
        }

        [Fact]
        public void FormulaFilterTest()
        {
            var filter = new FormulaFilter
            {
                Property = "Some",
                Formula = new FormulaFilterCondition
                {
                    Number = new NumberFilterCondition
                    {
                        IsEmpty = true
                    }
                },
            };

            Assert.Equal(
                "{\"formula\":{\"number\":{\"is_empty\":true}},\"property\":\"Some\"}",
                SerializeFilter(filter)
            );
        }

        [Fact]
        public void MultiSelectFilterTest()
        {
            var filter = new MultiSelectFilter
            {
                Property = "category 1",
                MultiSelect = new MultiSelectFilterCondition
                {
                    DoesNotContain = "tag"
                },
            };

            Assert.Equal(
                "{\"multi_select\":{\"does_not_contain\":\"tag\"},\"property\":\"category 1\"}",
                SerializeFilter(filter)
            );
        }

        [Fact(Skip = "Not sure if integer should be serialized as a number with decimals")]
        public void NumberFilterTest()
        {
            var filter = new NumberFilter
            {
                Property = "sum",
                Number = new NumberFilterCondition
                {
                    GreaterThanOrEqualTo = -54
                },
            };

            Assert.Equal(
                "{\"number\":{\"greater_than_or_equal_to\":-54.0},\"property\":\"sum\"}",
                SerializeFilter(filter)
            );
        }

        [Fact]
        public void PeopleFilter()
        {
            var filter = new PeopleFilter
            {
                Property = "assignee PM",
                People = new PeopleFilterCondition
                {
                    DoesNotContain = "some-uuid"
                },
            };

            Assert.Equal(
                "{\"people\":{\"does_not_contain\":\"some-uuid\"},\"property\":\"assignee PM\"}",
                SerializeFilter(filter)
            );
        }

        [Fact]
        public void TextFilterTest()
        {
            var filter = new TextFilter
            {
                Property = "Some property",
                Text = new TextFilterCondition
                {
                    DoesNotContain = "Example text"
                },
            };

            Assert.Equal(
                "{\"text\":{\"does_not_contain\":\"Example text\"},\"property\":\"Some property\"}",
                SerializeFilter(filter)
            );
        }
    }
}