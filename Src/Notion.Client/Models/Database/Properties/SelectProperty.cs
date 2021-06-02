using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class SelectProperty : Property
    {
        public override PropertyType Type => PropertyType.Select;
        public OptionWrapper<SelectOption> Select { get; set; }
    }

    public class OptionWrapper<T>
    {
        public List<T> Options { get; set; }
    }

    public class SelectOption
    {
        public string Name { get; set; }
        public string Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Color Color { get; set; }
    }

    public enum Color
    {
        [EnumMember(Value = null)]
        Unknown,

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

    public class MultiSelectProperty : Property
    {
        public override PropertyType Type => PropertyType.MultiSelect;

        [JsonProperty("multi_select")]
        public OptionWrapper<SelectOption> MultiSelect { get; set; }
    }
}
