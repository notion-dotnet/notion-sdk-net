using Newtonsoft.Json;

namespace Notion.Client
{
    public class RollupFilter : SinglePropertyFilter
    {
        public RollupFilter(
            string propertyName,
            IRollupSubPropertyFilter any = null,
            IRollupSubPropertyFilter none = null,
            IRollupSubPropertyFilter every = null,
            DateFilter.Condition date = null,
            NumberFilter.Condition number = null)
        {
            Property = propertyName;

            Rollup = new Condition(
                any,
                none,
                every,
                date,
                number
            );
        }

        [JsonProperty("rollup")]
        public Condition Rollup { get; set; }

        public class Condition
        {
            public Condition(
                IRollupSubPropertyFilter any = null,
                IRollupSubPropertyFilter none = null,
                IRollupSubPropertyFilter every = null,
                DateFilter.Condition date = null,
                NumberFilter.Condition number = null)
            {
                Any = any;
                None = none;
                Every = every;
                Date = date;
                Number = number;
            }

            [JsonProperty("any")]
            public IRollupSubPropertyFilter Any { get; set; }

            [JsonProperty("none")]
            public IRollupSubPropertyFilter None { get; set; }

            [JsonProperty("every")]
            public IRollupSubPropertyFilter Every { get; set; }

            [JsonProperty("date")]
            public DateFilter.Condition Date { get; set; }

            [JsonProperty("number")]
            public NumberFilter.Condition Number { get; set; }
        }
    }
}
