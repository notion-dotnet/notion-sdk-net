using Newtonsoft.Json;

namespace Notion.Client
{
    public class NumberFilter : SinglePropertyFilter
    {
        [JsonProperty("number")]
        public Condition Number { get; set; }

        public NumberFilter(
            string propertyName,
            double? equal = null,
            double? doesNotEqual = null,
            double? greaterThan = null,
            double? lessThan = null,
            double? greaterThanOrEqualTo = null,
            double? lessThanOrEqualTo = null,
            bool? isEmpty = null,
            bool? isNotEmpty = null)
        {
            Property = propertyName;
            Number = new Condition(
                equal: equal,
                doesNotEqual: doesNotEqual,
                greaterThan: greaterThan,
                lessThan: lessThan,
                greaterThanOrEqualTo: greaterThanOrEqualTo,
                lessThanOrEqualTo: lessThanOrEqualTo,
                isEmpty: isEmpty,
                isNotEmpty: isNotEmpty
            );
        }

        public class Condition
        {
            [JsonProperty("equals")]
            public double? Equal { get; set; }

            [JsonProperty("does_not_equal")]
            public double? DoesNotEqual { get; set; }

            [JsonProperty("greater_than")]
            public double? GreaterThan { get; set; }

            [JsonProperty("less_than")]
            public double? LessThan { get; set; }

            [JsonProperty("greater_than_or_equal_to")]
            public double? GreaterThanOrEqualTo { get; set; }

            [JsonProperty("less_than_or_equal_to")]
            public double? LessThanOrEqualTo { get; set; }

            [JsonProperty("is_empty")]
            public bool? IsEmpty { get; set; }

            [JsonProperty("is_not_empty")]
            public bool? IsNotEmpty { get; set; }

            public Condition(
                double? equal = null,
                double? doesNotEqual = null,
                double? greaterThan = null,
                double? lessThan = null,
                double? greaterThanOrEqualTo = null,
                double? lessThanOrEqualTo = null,
                bool? isEmpty = null,
                bool? isNotEmpty = null)
            {
                Equal = equal;
                DoesNotEqual = doesNotEqual;
                GreaterThan = greaterThan;
                LessThan = lessThan;
                GreaterThanOrEqualTo = greaterThanOrEqualTo;
                LessThanOrEqualTo = lessThanOrEqualTo;
                IsEmpty = isEmpty;
                IsNotEmpty = isNotEmpty;
            }
        }

    }
}
