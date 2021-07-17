using System;
using Notion.Client;
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
        [InlineData(typeof(FileProperty), PropertyType.File)]
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
    }
}
