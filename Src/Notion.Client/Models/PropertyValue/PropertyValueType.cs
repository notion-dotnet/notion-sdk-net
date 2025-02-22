using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Notion.Client
{
    /// <summary>
    ///     Types of Property Value
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum PropertyValueType
    {
        [EnumMember(Value = null)]
        Unknown,

        [EnumMember(Value = "rich_text")]
        RichText,

        [EnumMember(Value = "number")]
        Number,

        [EnumMember(Value = "select")]
        Select,

        [EnumMember(Value = "multi_select")]
        MultiSelect,

        [EnumMember(Value = "date")]
        Date,

        [EnumMember(Value = "formula")]
        Formula,

        [EnumMember(Value = "relation")]
        Relation,

        [EnumMember(Value = "rollup")]
        Rollup,

        [EnumMember(Value = "title")]
        Title,

        [EnumMember(Value = "people")]
        People,

        [EnumMember(Value = "files")]
        Files,

        [EnumMember(Value = "checkbox")]
        Checkbox,

        [EnumMember(Value = "url")]
        Url,

        [EnumMember(Value = "email")]
        Email,

        [EnumMember(Value = "phone_number")]
        PhoneNumber,

        [EnumMember(Value = "created_time")]
        CreatedTime,

        [EnumMember(Value = "created_by")]
        CreatedBy,

        [EnumMember(Value = "last_edited_time")]
        LastEditedTime,

        [EnumMember(Value = "last_edited_by")]
        LastEditedBy,

        [EnumMember(Value = "status")]
        Status,

        [EnumMember(Value = "unique_id")]
        UniqueId,

        [EnumMember(Value = "verification")]
        Verification,

        [EnumMember(Value = "button")]
        Button,
    }
}
