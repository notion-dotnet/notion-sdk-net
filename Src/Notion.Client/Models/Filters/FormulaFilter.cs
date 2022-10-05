using Newtonsoft.Json;

namespace Notion.Client
{
    public class FormulaFilter : SinglePropertyFilter
    {
        public FormulaFilter(
            string propertyName,
            TextFilter.Condition @string = null,
            CheckboxFilter.Condition checkbox = null,
            NumberFilter.Condition number = null,
            DateFilter.Condition date = null)
        {
            Property = propertyName;

            Formula = new Condition(
                @string,
                checkbox,
                number,
                date
            );
        }

        [JsonProperty("formula")]
        public Condition Formula { get; set; }

        public class Condition
        {
            public Condition(
                TextFilter.Condition @string = null,
                CheckboxFilter.Condition checkbox = null,
                NumberFilter.Condition number = null,
                DateFilter.Condition date = null)
            {
                String = @string;
                Checkbox = checkbox;
                Number = number;
                Date = date;
            }

            [JsonProperty("string")]
            public TextFilter.Condition String { get; set; }

            [JsonProperty("checkbox")]
            public CheckboxFilter.Condition Checkbox { get; set; }

            [JsonProperty("number")]
            public NumberFilter.Condition Number { get; set; }

            [JsonProperty("date")]
            public DateFilter.Condition Date { get; set; }
        }
    }
}
