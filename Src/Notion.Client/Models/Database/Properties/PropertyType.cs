using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Represents the type of a Notion database property.
    /// New values introduced by Notion are preserved as-is rather than causing a deserialization failure.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<PropertyType>))]
    public readonly struct PropertyType : IEquatable<PropertyType>
    {
        private readonly string _value;

        public PropertyType(string value) => _value = value;

        public const string TitleValue = "title";
        public const string RichTextValue = "rich_text";
        public const string NumberValue = "number";
        public const string SelectValue = "select";
        public const string MultiSelectValue = "multi_select";
        public const string DateValue = "date";
        public const string PeopleValue = "people";
        public const string FilesValue = "files";
        public const string CheckboxValue = "checkbox";
        public const string UrlValue = "url";
        public const string EmailValue = "email";
        public const string PhoneNumberValue = "phone_number";
        public const string FormulaValue = "formula";
        public const string RelationValue = "relation";
        public const string RollupValue = "rollup";
        public const string CreatedTimeValue = "created_time";
        public const string CreatedByValue = "created_by";
        public const string LastEditedByValue = "last_edited_by";
        public const string LastEditedTimeValue = "last_edited_time";
        public const string StatusValue = "status";
        public const string UniqueIdValue = "unique_id";
        public const string ButtonValue = "button";
        public const string VerificationValue = "verification";
        public const string PlaceValue = "place";

        public static readonly PropertyType Title = new PropertyType(TitleValue);
        public static readonly PropertyType RichText = new PropertyType(RichTextValue);
        public static readonly PropertyType Number = new PropertyType(NumberValue);
        public static readonly PropertyType Select = new PropertyType(SelectValue);
        public static readonly PropertyType MultiSelect = new PropertyType(MultiSelectValue);
        public static readonly PropertyType Date = new PropertyType(DateValue);
        public static readonly PropertyType People = new PropertyType(PeopleValue);
        public static readonly PropertyType Files = new PropertyType(FilesValue);
        public static readonly PropertyType Checkbox = new PropertyType(CheckboxValue);
        public static readonly PropertyType Url = new PropertyType(UrlValue);
        public static readonly PropertyType Email = new PropertyType(EmailValue);
        public static readonly PropertyType PhoneNumber = new PropertyType(PhoneNumberValue);
        public static readonly PropertyType Formula = new PropertyType(FormulaValue);
        public static readonly PropertyType Relation = new PropertyType(RelationValue);
        public static readonly PropertyType Rollup = new PropertyType(RollupValue);
        public static readonly PropertyType CreatedTime = new PropertyType(CreatedTimeValue);
        public static readonly PropertyType CreatedBy = new PropertyType(CreatedByValue);
        public static readonly PropertyType LastEditedBy = new PropertyType(LastEditedByValue);
        public static readonly PropertyType LastEditedTime = new PropertyType(LastEditedTimeValue);
        public static readonly PropertyType Status = new PropertyType(StatusValue);
        public static readonly PropertyType UniqueId = new PropertyType(UniqueIdValue);
        public static readonly PropertyType Button = new PropertyType(ButtonValue);
        public static readonly PropertyType Verification = new PropertyType(VerificationValue);
        public static readonly PropertyType Place = new PropertyType(PlaceValue);

        public static implicit operator PropertyType(string value) => new PropertyType(value);

        public static bool operator ==(PropertyType left, PropertyType right) => left.Equals(right);
        public static bool operator !=(PropertyType left, PropertyType right) => !left.Equals(right);

        public bool Equals(PropertyType other) =>
            string.Equals(_value, other._value, StringComparison.Ordinal);

        public override bool Equals(object obj) => obj is PropertyType other && Equals(other);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value ?? string.Empty;
    }
}
