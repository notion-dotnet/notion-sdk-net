using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Properties of meeting notes that can be filtered or sorted on.
    /// </summary>
    public static class MeetingNotesPropertyName
    {
        public const string Title = "title";
        public const string CreatedTime = "created_time";
        public const string LastEditedTime = "last_edited_time";
        public const string CreatedBy = "created_by";
        public const string LastEditedBy = "last_edited_by";
        public const string Attendees = "attendees";
    }

    /// <summary>
    ///     Operators accepted by meeting notes filters.
    /// </summary>
    public static class MeetingNotesFilterOperator
    {
        // Combinators
        public const string And = "and";
        public const string Or = "or";

        // Any property
        public const string IsEmpty = "is_empty";
        public const string IsNotEmpty = "is_not_empty";

        // Text (title)
        public const string StringIs = "string_is";
        public const string StringIsNot = "string_is_not";
        public const string StringContains = "string_contains";
        public const string StringDoesNotContain = "string_does_not_contain";
        public const string StringStartsWith = "string_starts_with";
        public const string StringEndsWith = "string_ends_with";

        // Date (created_time, last_edited_time)
        public const string DateIs = "date_is";
        public const string DateIsBefore = "date_is_before";
        public const string DateIsAfter = "date_is_after";
        public const string DateIsOnOrBefore = "date_is_on_or_before";
        public const string DateIsOnOrAfter = "date_is_on_or_after";
        public const string DateIsWithin = "date_is_within";
        public const string DateIsRelativeTo = "date_is_relative_to";

        // Person (created_by, last_edited_by, attendees)
        public const string PersonContains = "person_contains";
        public const string PersonDoesNotContain = "person_does_not_contain";
    }

    /// <summary>
    ///     A node in a meeting notes filter tree: a combinator or a property filter.
    /// </summary>
    public abstract class MeetingNotesFilterNode
    {
    }

    /// <summary>
    ///     Combines child filters with <c>and</c> / <c>or</c>.
    /// </summary>
    public class MeetingNotesCombinatorFilter : MeetingNotesFilterNode
    {
        public MeetingNotesCombinatorFilter(string @operator, params MeetingNotesFilterNode[] filters)
        {
            Operator = @operator;
            Filters = new List<MeetingNotesFilterNode>(filters);
        }

        [JsonProperty("operator")]
        public string Operator { get; set; }

        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public List<MeetingNotesFilterNode> Filters { get; set; }

        public static MeetingNotesCombinatorFilter And(params MeetingNotesFilterNode[] filters) =>
            new MeetingNotesCombinatorFilter(MeetingNotesFilterOperator.And, filters);

        public static MeetingNotesCombinatorFilter Or(params MeetingNotesFilterNode[] filters) =>
            new MeetingNotesCombinatorFilter(MeetingNotesFilterOperator.Or, filters);
    }

    /// <summary>
    ///     Filters one property (see <see cref="MeetingNotesPropertyName" />) with a condition.
    /// </summary>
    public class MeetingNotesPropertyFilter : MeetingNotesFilterNode
    {
        public MeetingNotesPropertyFilter(string property, MeetingNotesFilterCondition filter)
        {
            Property = property;
            Filter = filter;
        }

        [JsonProperty("property")]
        public string Property { get; set; }

        [JsonProperty("filter")]
        public MeetingNotesFilterCondition Filter { get; set; }
    }

    /// <summary>
    ///     An operator with its (optional) value. Use the factory methods to build valid conditions.
    /// </summary>
    public class MeetingNotesFilterCondition
    {
        [JsonProperty("operator")]
        public string Operator { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public object Value { get; set; }

        /// <summary>
        ///     <c>is_empty</c> / <c>is_not_empty</c>; works for every property.
        /// </summary>
        public static MeetingNotesFilterCondition Empty(bool isEmpty = true) =>
            new MeetingNotesFilterCondition
            {
                Operator = isEmpty ? MeetingNotesFilterOperator.IsEmpty : MeetingNotesFilterOperator.IsNotEmpty
            };

        /// <summary>
        ///     Text condition for <c>title</c>, e.g. <see cref="MeetingNotesFilterOperator.StringContains" />.
        /// </summary>
        public static MeetingNotesFilterCondition Text(string @operator, string text) =>
            Exact(@operator, text);

        /// <summary>
        ///     Date condition against an exact ISO 8601 date, e.g. "2026-01-31".
        /// </summary>
        public static MeetingNotesFilterCondition DateExact(string @operator, string isoDate) =>
            Exact(@operator, isoDate);

        /// <summary>
        ///     Date condition against a relative date such as "today" or "yesterday".
        /// </summary>
        public static MeetingNotesFilterCondition DateRelative(string @operator, string relativeDate) =>
            new MeetingNotesFilterCondition
            {
                Operator = @operator,
                Value = new Dictionary<string, object> { { "type", "relative" }, { "value", relativeDate } }
            };

        /// <summary>
        ///     Person condition for <c>created_by</c>, <c>last_edited_by</c> or <c>attendees</c>.
        /// </summary>
        public static MeetingNotesFilterCondition Person(string @operator, string userId) =>
            Exact(
                @operator,
                new Dictionary<string, object> { { "table", "notion_user" }, { "id", userId } });

        private static MeetingNotesFilterCondition Exact(string @operator, object value) =>
            new MeetingNotesFilterCondition
            {
                Operator = @operator,
                Value = new Dictionary<string, object> { { "type", "exact" }, { "value", value } }
            };
    }

    /// <summary>
    ///     Sort for a meeting notes query.
    /// </summary>
    public class MeetingNotesSort
    {
        public const string Ascending = "ascending";
        public const string Descending = "descending";

        [JsonProperty("property")]
        public string Property { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; } = Ascending;
    }
}
