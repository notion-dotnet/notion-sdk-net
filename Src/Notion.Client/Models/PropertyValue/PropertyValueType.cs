using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Represents the type of a Notion page property value.
    /// New values introduced by Notion are preserved as-is rather than causing a deserialization failure.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<PropertyValueType>))]
    public readonly struct PropertyValueType : IEquatable<PropertyValueType>
    {
        private readonly string _value;

        public PropertyValueType(string value) => _value = value;

        public const string RichTextValue = "rich_text";
        public const string NumberValue = "number";
        public const string SelectValue = "select";
        public const string MultiSelectValue = "multi_select";
        public const string DateValue = "date";
        public const string FormulaValue = "formula";
        public const string RelationValue = "relation";
        public const string RollupValue = "rollup";
        public const string TitleValue = "title";
        public const string PeopleValue = "people";
        public const string FilesValue = "files";
        public const string CheckboxValue = "checkbox";
        public const string UrlValue = "url";
        public const string EmailValue = "email";
        public const string PhoneNumberValue = "phone_number";
        public const string CreatedTimeValue = "created_time";
        public const string CreatedByValue = "created_by";
        public const string LastEditedTimeValue = "last_edited_time";
        public const string LastEditedByValue = "last_edited_by";
        public const string StatusValue = "status";
        public const string UniqueIdValue = "unique_id";
        public const string VerificationValue = "verification";
        public const string ButtonValue = "button";
        public const string PlaceValue = "place";

        public static readonly PropertyValueType RichText = new PropertyValueType(RichTextValue);
        public static readonly PropertyValueType Number = new PropertyValueType(NumberValue);
        public static readonly PropertyValueType Select = new PropertyValueType(SelectValue);
        public static readonly PropertyValueType MultiSelect = new PropertyValueType(MultiSelectValue);
        public static readonly PropertyValueType Date = new PropertyValueType(DateValue);
        public static readonly PropertyValueType Formula = new PropertyValueType(FormulaValue);
        public static readonly PropertyValueType Relation = new PropertyValueType(RelationValue);
        public static readonly PropertyValueType Rollup = new PropertyValueType(RollupValue);
        public static readonly PropertyValueType Title = new PropertyValueType(TitleValue);
        public static readonly PropertyValueType People = new PropertyValueType(PeopleValue);
        public static readonly PropertyValueType Files = new PropertyValueType(FilesValue);
        public static readonly PropertyValueType Checkbox = new PropertyValueType(CheckboxValue);
        public static readonly PropertyValueType Url = new PropertyValueType(UrlValue);
        public static readonly PropertyValueType Email = new PropertyValueType(EmailValue);
        public static readonly PropertyValueType PhoneNumber = new PropertyValueType(PhoneNumberValue);
        public static readonly PropertyValueType CreatedTime = new PropertyValueType(CreatedTimeValue);
        public static readonly PropertyValueType CreatedBy = new PropertyValueType(CreatedByValue);
        public static readonly PropertyValueType LastEditedTime = new PropertyValueType(LastEditedTimeValue);
        public static readonly PropertyValueType LastEditedBy = new PropertyValueType(LastEditedByValue);
        public static readonly PropertyValueType Status = new PropertyValueType(StatusValue);
        public static readonly PropertyValueType UniqueId = new PropertyValueType(UniqueIdValue);
        public static readonly PropertyValueType Verification = new PropertyValueType(VerificationValue);
        public static readonly PropertyValueType Button = new PropertyValueType(ButtonValue);
        public static readonly PropertyValueType Place = new PropertyValueType(PlaceValue);

        public static implicit operator PropertyValueType(string value) => new PropertyValueType(value);

        public static bool operator ==(PropertyValueType left, PropertyValueType right) => left.Equals(right);
        public static bool operator !=(PropertyValueType left, PropertyValueType right) => !left.Equals(right);

        public bool Equals(PropertyValueType other) =>
            string.Equals(_value, other._value, StringComparison.Ordinal);

        public override bool Equals(object obj) => obj is PropertyValueType other && Equals(other);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value ?? string.Empty;
    }
}
