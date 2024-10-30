using System;
using Notion.Client;
using Notion.Client.Extensions;
using Xunit;

namespace Notion.UnitTests;

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
    [InlineData(typeof(UniqueIdProperty), PropertyType.UniqueId)]
    [InlineData(typeof(ButtonProperty),PropertyType.Button)]
    public void TestPropertyType(Type type, PropertyType expectedPropertyType)
    {
        var typeInstance = (Property)Activator.CreateInstance(type);

        var actualPropertyType = typeInstance!.Type;

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
    [InlineData(typeof(UniqueIdProperty), "unique_id")]
    [InlineData(typeof(ButtonProperty), "button")]
    public void TestPropertyTypeText(Type type, string expectedPropertyType)
    {
        var typeInstance = (Property)Activator.CreateInstance(type);

        var actualPropertyType = typeInstance!.Type.GetEnumMemberValue();

        Assert.Equal(expectedPropertyType, actualPropertyType);
    }
}
