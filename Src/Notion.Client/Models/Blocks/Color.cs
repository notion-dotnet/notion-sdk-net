using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum Color
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
        Red,

        [EnumMember(Value = "gray_background")]
        GrayBackground,

        [EnumMember(Value = "brown_background")]
        BrownBackground,

        [EnumMember(Value = "orange_background")]
        OrangeBackground,

        [EnumMember(Value = "yellow_background")]
        YellowBackground,

        [EnumMember(Value = "green_background")]
        GreenBackground,

        [EnumMember(Value = "blue_background")]
        BlueBackground,

        [EnumMember(Value = "purple_background")]
        PurpleBackground,

        [EnumMember(Value = "pink_background")]
        PinkBackground,

        [EnumMember(Value = "red_background")]
        RedBackground
    }
}
