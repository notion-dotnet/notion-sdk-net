using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class Filter
    {

    }

    public class SinglePropertyFilter : Filter
    {
        public string Property { get; set; }
    }

    public class TextFilter : SinglePropertyFilter
    {
        [JsonProperty("equals")]
        public string Equal { get; set; }

        [JsonProperty("does_not_equal")]
        public string DoesNotEqual { get; set; }

        public string Contains { get; set; }

        [JsonProperty("does_not_contain")]
        public string DoesNotContain { get; set; }


        [JsonProperty("starts_with")]
        public string StartsWith { get; set; }

        [JsonProperty("ends_with")]
        public string EndsWith { get; set; }

        [JsonProperty("is_empty")]
        public bool IsEmpty => true;

        [JsonProperty("is_not_empty")]
        public bool IsNotEmpty => true;
    }

    public class NumberFilter : SinglePropertyFilter
    {
        [JsonProperty("equals")]
        public double Equal { get; set; }

        [JsonProperty("does_not_equal")]
        public double DoesNotEqual { get; set; }

        [JsonProperty("greater_than")]
        public double GreaterThan { get; set; }

        [JsonProperty("less_than")]
        public double LessThan { get; set; }

        [JsonProperty("greater_than_or_equal_to")]
        public double GreaterThanOrEqualTo { get; set; }

        [JsonProperty("less_than_or_equal_to")]
        public double LessThanOrEqualTo { get; set; }

        [JsonProperty("is_empty")]
        public bool IsEmpty => true;

        [JsonProperty("is_not_empty")]
        public bool IsNotEmpty => true;
    }

    public class CheckboxFilter : SinglePropertyFilter
    {
        [JsonProperty("equals")]
        public bool Equal { get; set; }

        [JsonProperty("does_not_equal")]
        public bool DoesNotEqual { get; set; }
    }

    public class SelectFilter : SinglePropertyFilter
    {
        [JsonProperty("equals")]
        public string Equal { get; set; }

        [JsonProperty("does_not_equal")]
        public string DoesNotEqual { get; set; }

        [JsonProperty("is_empty")]
        public bool IsEmpty => true;

        [JsonProperty("is_not_empty")]
        public bool IsNotEmpty => true;
    }

    public class MultiSelectFilter : SinglePropertyFilter
    {
        public string Contains { get; set; }

        [JsonProperty("does_not_contain")]
        public string DoesNotContain { get; set; }

        [JsonProperty("is_empty")]
        public bool IsEmpty => true;

        [JsonProperty("is_not_empty")]
        public bool IsNotEmpty => true;
    }

    public class DateFilter : SinglePropertyFilter
    {
        [JsonProperty("equals")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Equal { get; set; }

        [JsonProperty("before")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Before { get; set; }

        [JsonProperty("after")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime After { get; set; }

        [JsonProperty("on_or_before")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime OnOrBefore { get; set; }

        [JsonProperty("on_or_after")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime OnOrAfter { get; set; }

        [JsonProperty("past_week")]
        public Dictionary<string, object> PastWeek { get; set; }

        [JsonProperty("past_month")]
        public Dictionary<string, object> PastMonth { get; set; }

        [JsonProperty("past_year")]
        public Dictionary<string, object> PastYear { get; set; }

        [JsonProperty("next_week")]
        public Dictionary<string, object> NextWeek { get; set; }

        [JsonProperty("next_month")]
        public Dictionary<string, object> NextMonth { get; set; }

        [JsonProperty("next_year")]
        public Dictionary<string, object> NextYear { get; set; }

        [JsonProperty("is_empty")]
        public bool IsEmpty => true;

        [JsonProperty("is_not_empty")]
        public bool IsNotEmpty => true;
    }

    public class PeopleFilter : SinglePropertyFilter
    {
        public string Contains { get; set; }

        [JsonProperty("does_not_contain")]
        public string DoesNotContain { get; set; }

        [JsonProperty("is_empty")]
        public bool IsEmpty => true;

        [JsonProperty("is_not_empty")]
        public bool IsNotEmpty => true;
    }

    public class FilesFilter : SinglePropertyFilter
    {
        [JsonProperty("is_empty")]
        public bool IsEmpty => true;

        [JsonProperty("is_not_empty")]
        public bool IsNotEmpty => true;
    }

    public class RelationFilter : SinglePropertyFilter
    {
        public string Contains { get; set; }

        [JsonProperty("does_not_contain")]
        public string DoesNotContain { get; set; }

        [JsonProperty("is_empty")]
        public bool IsEmpty => true;

        [JsonProperty("is_not_empty")]
        public bool IsNotEmpty => true;
    }

    public class FormulaFilter : SinglePropertyFilter
    {
        public TextFilter Text { get; set; }
        public CheckboxFilter checkbox { get; set; }
        public NumberFilter number { get; set; }
        public DateFilter date { get; set; }
    }


    public class CompoundFilter : Filter
    {
        public List<Filter> Or { get; set; }
        public List<Filter> And { get; set; }
    }
}
