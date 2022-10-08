using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    /// <summary>
    ///     Status property value objects contain page status
    /// </summary>
    public class StatusPropertyValue : PropertyValue
    {
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public enum StatusColor
        {
            [EnumMember(Value = "default")]
            Default,

            [EnumMember(Value = "gray")]
            Gray,

            [EnumMember(Value = "brown")]
            Brown,

            [EnumMember(Value = "orange")]
            Orange,

            [EnumMember(Value = "yellow")]
            Yellow,

            [EnumMember(Value = "green")]
            Green,

            [EnumMember(Value = "blue")]
            Blue,

            [EnumMember(Value = "purple")]
            Purple,

            [EnumMember(Value = "pink")]
            Pink,

            [EnumMember(Value = "red")]
            Red
        }

        public override PropertyValueType Type => PropertyValueType.Status;

        [JsonProperty("status")]
        public Data Status { get; set; }

        public class Data
        {
            /// <summary>
            ///     ID of the option.
            /// </summary>
            [JsonProperty("id")]
            public string Id { get; set; }

            /// <summary>
            ///     Name of the option as it appears in Notion.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            ///     Color of the option.
            /// </summary>
            [JsonProperty("color")]
            [JsonConverter(typeof(StringEnumConverter))]
            public StatusColor? Color { get; set; }
        }
    }
}
