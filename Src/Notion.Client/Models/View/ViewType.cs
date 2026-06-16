using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Represents the type of a Notion view.
    /// New values introduced by Notion are preserved as-is rather than causing a deserialization failure.
    /// Use the <c>const string</c> members (e.g. <see cref="TableValue"/>) when referencing a value
    /// in a <c>[JsonSubtypes.KnownSubType]</c> attribute; use the <c>static readonly</c> fields
    /// (e.g. <see cref="Table"/>) everywhere else.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<ViewType>))]
    public readonly struct ViewType : IEquatable<ViewType>
    {
        private readonly string _value;

        public ViewType(string value) => _value = value;

        public const string TableValue = "table";
        public const string BoardValue = "board";
        public const string ListValue = "list";
        public const string CalendarValue = "calendar";
        public const string TimelineValue = "timeline";
        public const string GalleryValue = "gallery";
        public const string FormValue = "form";
        public const string ChartValue = "chart";
        public const string MapValue = "map";
        public const string DashboardValue = "dashboard";

        public static readonly ViewType Table = new ViewType(TableValue);
        public static readonly ViewType Board = new ViewType(BoardValue);
        public static readonly ViewType List = new ViewType(ListValue);
        public static readonly ViewType Calendar = new ViewType(CalendarValue);
        public static readonly ViewType Timeline = new ViewType(TimelineValue);
        public static readonly ViewType Gallery = new ViewType(GalleryValue);
        public static readonly ViewType Form = new ViewType(FormValue);
        public static readonly ViewType Chart = new ViewType(ChartValue);
        public static readonly ViewType Map = new ViewType(MapValue);
        public static readonly ViewType Dashboard = new ViewType(DashboardValue);

        public static implicit operator ViewType(string value) => new ViewType(value);

        public static bool operator ==(ViewType left, ViewType right) => left.Equals(right);
        public static bool operator !=(ViewType left, ViewType right) => !left.Equals(right);

        public bool Equals(ViewType other) =>
            string.Equals(_value, other._value, StringComparison.Ordinal);

        public override bool Equals(object obj) => obj is ViewType other && Equals(other);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value ?? string.Empty;
    }
}
