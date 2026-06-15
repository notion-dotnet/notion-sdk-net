using System;
using Notion.Client;
using Xunit;

namespace Notion.UnitTests;

public class PropertyTests
{
    [Theory]
    [InlineData(typeof(CheckboxProperty), PropertyType.CheckboxValue)]
    [InlineData(typeof(CreatedByProperty), PropertyType.CreatedByValue)]
    [InlineData(typeof(CreatedTimeProperty), PropertyType.CreatedTimeValue)]
    [InlineData(typeof(DateProperty), PropertyType.DateValue)]
    [InlineData(typeof(EmailProperty), PropertyType.EmailValue)]
    [InlineData(typeof(FilesProperty), PropertyType.FilesValue)]
    [InlineData(typeof(FormulaProperty), PropertyType.FormulaValue)]
    [InlineData(typeof(LastEditedByProperty), PropertyType.LastEditedByValue)]
    [InlineData(typeof(LastEditedTimeProperty), PropertyType.LastEditedTimeValue)]
    [InlineData(typeof(NumberProperty), PropertyType.NumberValue)]
    [InlineData(typeof(PeopleProperty), PropertyType.PeopleValue)]
    [InlineData(typeof(PhoneNumberProperty), PropertyType.PhoneNumberValue)]
    [InlineData(typeof(RelationProperty), PropertyType.RelationValue)]
    [InlineData(typeof(RichTextProperty), PropertyType.RichTextValue)]
    [InlineData(typeof(RollupProperty), PropertyType.RollupValue)]
    [InlineData(typeof(SelectProperty), PropertyType.SelectValue)]
    [InlineData(typeof(TitleProperty), PropertyType.TitleValue)]
    [InlineData(typeof(UrlProperty), PropertyType.UrlValue)]
    [InlineData(typeof(UniqueIdProperty), PropertyType.UniqueIdValue)]
    [InlineData(typeof(ButtonProperty), PropertyType.ButtonValue)]
    public void TestPropertyType(Type type, string expectedPropertyType)
    {
        var typeInstance = (Property)Activator.CreateInstance(type);

        Assert.Equal(expectedPropertyType, typeInstance!.Type.ToString());
    }
}
