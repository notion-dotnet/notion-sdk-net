using System;
using FluentAssertions;
using Notion.Client;
using Notion.Client.Extensions;
using Xunit;

namespace Notion.UnitTests
{
    public class PropertyTests
    {
        [Theory]
        [InlineData(typeof(CheckboxProperty), PropertyType.Checkbox)]
        [InlineData(typeof(CreatedByProperty), PropertyType.CreatedBy)]
        [InlineData(typeof(CreatedTimeProperty), PropertyType.CreatedTime)]
        [InlineData(typeof(DateProperty), PropertyType.Date)]
        [InlineData(typeof(EmailProperty), PropertyType.Email)]
        [InlineData(typeof(FilesProperty), PropertyType.Files)]
        [InlineData(typeof(FormulaProperty), PropertyType.Formula)]
        [InlineData(typeof(LastEditedByProperty), PropertyType.LastEditedBy)]
        [InlineData(typeof(LastEditedTimeProperty), PropertyType.LastEditedTime)]
        [InlineData(typeof(NumberProperty), PropertyType.Number)]
        [InlineData(typeof(PeopleProperty), PropertyType.People)]
        [InlineData(typeof(PhoneNumberProperty), PropertyType.PhoneNumber)]
        [InlineData(typeof(RelationProperty), PropertyType.Relation)]
        [InlineData(typeof(RichTextProperty), PropertyType.RichText)]
        [InlineData(typeof(RollupProperty), PropertyType.Rollup)]
        [InlineData(typeof(SelectProperty), PropertyType.Select)]
        [InlineData(typeof(TitleProperty), PropertyType.Title)]
        [InlineData(typeof(UrlProperty), PropertyType.Url)]
        public void TestPropertyType(Type type, PropertyType expectedPropertyType)
        {
            var typeInstance = (Property)Activator.CreateInstance(type);

            var actualPropertyType = typeInstance.Type;

            Assert.Equal(expectedPropertyType, actualPropertyType);
        }

        [Theory]
        [InlineData(typeof(CheckboxProperty), "checkbox")]
        [InlineData(typeof(CreatedByProperty), "created_by")]
        [InlineData(typeof(CreatedTimeProperty), "created_time")]
        [InlineData(typeof(DateProperty), "date")]
        [InlineData(typeof(EmailProperty), "email")]
        [InlineData(typeof(FilesProperty), "files")]
        [InlineData(typeof(FormulaProperty), "formula")]
        [InlineData(typeof(LastEditedByProperty), "last_edited_by")]
        [InlineData(typeof(LastEditedTimeProperty), "last_edited_time")]
        [InlineData(typeof(NumberProperty), "number")]
        [InlineData(typeof(PeopleProperty), "people")]
        [InlineData(typeof(PhoneNumberProperty), "phone_number")]
        [InlineData(typeof(RelationProperty), "relation")]
        [InlineData(typeof(RichTextProperty), "rich_text")]
        [InlineData(typeof(RollupProperty), "rollup")]
        [InlineData(typeof(SelectProperty), "select")]
        [InlineData(typeof(TitleProperty), "title")]
        [InlineData(typeof(UrlProperty), "url")]
        public void TestPropertyTypeText(Type type, string expectedPropertyType)
        {
            var typeInstance = (Property)Activator.CreateInstance(type);

            var actualPropertyType = typeInstance.Type.GetEnumMemberValue();

            Assert.Equal(expectedPropertyType, actualPropertyType);
        }

        [Theory]
        [InlineData(null, NumberFormat.Unknown)]
        [InlineData("number", NumberFormat.Number)]
        [InlineData("number_with_commas", NumberFormat.NumberWithCommas)]
        [InlineData("percent", NumberFormat.Percent)]
        [InlineData("dollar", NumberFormat.Dollar)]
        [InlineData("euro", NumberFormat.Euro)]
        [InlineData("pound", NumberFormat.Pound)]
        [InlineData("yen", NumberFormat.Yen)]
        [InlineData("ruble", NumberFormat.Ruble)]
        [InlineData("rupee", NumberFormat.Rupee)]
        [InlineData("won", NumberFormat.Won)]
        [InlineData("yuan", NumberFormat.Yuan)]
        [InlineData("hong_kong_dollar", NumberFormat.HongKongDollar)]
        [InlineData("new_zealand_dollar", NumberFormat.NewZealandDollar)]
        [InlineData("krona", NumberFormat.Krona)]
        [InlineData("norwegian_krone", NumberFormat.NorwegianKrone)]
        [InlineData("mexican_peso", NumberFormat.MexicanPeso)]
        [InlineData("rand", NumberFormat.Rand)]
        [InlineData("new_taiwan_dollar", NumberFormat.NewTaiwanDollar)]
        [InlineData("danish_krone", NumberFormat.DanishKrone)]
        [InlineData("zloty", NumberFormat.Zloty)]
        [InlineData("baht", NumberFormat.Baht)]
        [InlineData("forint", NumberFormat.Forint)]
        [InlineData("koruna", NumberFormat.Koruna)]
        [InlineData("shekel", NumberFormat.Shekel)]
        [InlineData("chilean_peso", NumberFormat.ChileanPeso)]
        [InlineData("philippine_peso", NumberFormat.PhilippinePeso)]
        [InlineData("dirham", NumberFormat.Dirham)]
        [InlineData("colombian_peso", NumberFormat.ColombianPeso)]
        [InlineData("riyal", NumberFormat.Riyal)]
        [InlineData("ringgit", NumberFormat.Ringgit)]
        [InlineData("leu", NumberFormat.Leu)]
        public void NumberFormatEnumTypes(string textValue, NumberFormat numberFormat)
        {
            numberFormat.GetEnumMemberValue().Should().Be(textValue);
        }
    }
}
