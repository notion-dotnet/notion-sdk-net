namespace Notion.Client
{
    public class FormulaFilter : SinglePropertyFilter
    {
        public Condition Formula { get; set; }

        public class Condition
        {
            public TextFilter.Condition Text { get; set; }
            public CheckboxFilter.Condition Checkbox { get; set; }
            public NumberFilter.Condition Number { get; set; }
            public DateFilter.Condition Date { get; set; }
        }
    }
}