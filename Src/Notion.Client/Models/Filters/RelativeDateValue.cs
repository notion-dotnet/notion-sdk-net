using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Represents a date filter value that can be either an ISO 8601 date string or a relative date keyword.
    /// Relative keywords are resolved at query time relative to the current date.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<RelativeDateValue>))]
    public readonly struct RelativeDateValue : IEquatable<RelativeDateValue>
    {
        private readonly string _value;

        public RelativeDateValue(string value) => _value = value;

        public const string TodayValue = "today";
        public const string TomorrowValue = "tomorrow";
        public const string YesterdayValue = "yesterday";
        public const string OneWeekAgoValue = "one_week_ago";
        public const string OneWeekFromNowValue = "one_week_from_now";
        public const string OneMonthAgoValue = "one_month_ago";
        public const string OneMonthFromNowValue = "one_month_from_now";

        public static readonly RelativeDateValue Today = new RelativeDateValue(TodayValue);
        public static readonly RelativeDateValue Tomorrow = new RelativeDateValue(TomorrowValue);
        public static readonly RelativeDateValue Yesterday = new RelativeDateValue(YesterdayValue);
        public static readonly RelativeDateValue OneWeekAgo = new RelativeDateValue(OneWeekAgoValue);
        public static readonly RelativeDateValue OneWeekFromNow = new RelativeDateValue(OneWeekFromNowValue);
        public static readonly RelativeDateValue OneMonthAgo = new RelativeDateValue(OneMonthAgoValue);
        public static readonly RelativeDateValue OneMonthFromNow = new RelativeDateValue(OneMonthFromNowValue);

        public static implicit operator RelativeDateValue(string value) => new RelativeDateValue(value);

        public static implicit operator RelativeDateValue(DateTime value)
        {
            string formatted;
            if (value.Kind == DateTimeKind.Utc)
                formatted = value.ToString("yyyy-MM-ddTHH:mm:ssZ");
            else if (value.Kind == DateTimeKind.Local)
                formatted = value.ToString("yyyy-MM-ddTHH:mm:sszzz");
            else
                formatted = value.ToString("yyyy-MM-ddTHH:mm:ss");
            return new RelativeDateValue(formatted);
        }

        public static implicit operator RelativeDateValue(DateTimeOffset value)
            => new RelativeDateValue(value.ToString("yyyy-MM-ddTHH:mm:sszzz"));

        public static bool operator ==(RelativeDateValue left, RelativeDateValue right) => left.Equals(right);
        public static bool operator !=(RelativeDateValue left, RelativeDateValue right) => !left.Equals(right);

        public bool Equals(RelativeDateValue other) =>
            string.Equals(_value, other._value, StringComparison.Ordinal);

        public override bool Equals(object obj) => obj is RelativeDateValue other && Equals(other);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value ?? string.Empty;
    }
}
