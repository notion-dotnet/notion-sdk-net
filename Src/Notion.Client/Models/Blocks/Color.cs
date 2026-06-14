using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Represents a Notion color value.
    /// New values introduced by Notion are preserved as-is rather than causing a deserialization failure.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<Color>))]
    public readonly struct Color : IEquatable<Color>
    {
        private readonly string _value;

        public Color(string value) => _value = value;

        public const string DefaultValue = "default";
        public const string GrayValue = "gray";
        public const string BrownValue = "brown";
        public const string OrangeValue = "orange";
        public const string YellowValue = "yellow";
        public const string GreenValue = "green";
        public const string BlueValue = "blue";
        public const string PurpleValue = "purple";
        public const string PinkValue = "pink";
        public const string RedValue = "red";
        public const string DefaultBackgroundValue = "default_background";
        public const string GrayBackgroundValue = "gray_background";
        public const string BrownBackgroundValue = "brown_background";
        public const string OrangeBackgroundValue = "orange_background";
        public const string YellowBackgroundValue = "yellow_background";
        public const string GreenBackgroundValue = "green_background";
        public const string BlueBackgroundValue = "blue_background";
        public const string PurpleBackgroundValue = "purple_background";
        public const string PinkBackgroundValue = "pink_background";
        public const string RedBackgroundValue = "red_background";

        public static readonly Color Default = new Color(DefaultValue);
        public static readonly Color Gray = new Color(GrayValue);
        public static readonly Color Brown = new Color(BrownValue);
        public static readonly Color Orange = new Color(OrangeValue);
        public static readonly Color Yellow = new Color(YellowValue);
        public static readonly Color Green = new Color(GreenValue);
        public static readonly Color Blue = new Color(BlueValue);
        public static readonly Color Purple = new Color(PurpleValue);
        public static readonly Color Pink = new Color(PinkValue);
        public static readonly Color Red = new Color(RedValue);
        public static readonly Color DefaultBackground = new Color(DefaultBackgroundValue);
        public static readonly Color GrayBackground = new Color(GrayBackgroundValue);
        public static readonly Color BrownBackground = new Color(BrownBackgroundValue);
        public static readonly Color OrangeBackground = new Color(OrangeBackgroundValue);
        public static readonly Color YellowBackground = new Color(YellowBackgroundValue);
        public static readonly Color GreenBackground = new Color(GreenBackgroundValue);
        public static readonly Color BlueBackground = new Color(BlueBackgroundValue);
        public static readonly Color PurpleBackground = new Color(PurpleBackgroundValue);
        public static readonly Color PinkBackground = new Color(PinkBackgroundValue);
        public static readonly Color RedBackground = new Color(RedBackgroundValue);

        public static implicit operator Color(string value) => new Color(value);

        public static bool operator ==(Color left, Color right) => left.Equals(right);
        public static bool operator !=(Color left, Color right) => !left.Equals(right);

        public bool Equals(Color other) =>
            string.Equals(_value, other._value, StringComparison.Ordinal);

        public override bool Equals(object obj) => obj is Color other && Equals(other);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value ?? string.Empty;
    }
}
