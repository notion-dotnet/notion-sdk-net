namespace Notion.Client
{
    public class FormulaFilter : SinglePropertyFilter
    {
        public Condition Formula { get; set; }

        public FormulaFilter(
            string propertyName,
            TextFilter.Condition text = null,
            CheckboxFilter.Condition checkbox = null,
            NumberFilter.Condition number = null,
            DateFilter.Condition date = null)
        {
            Property = propertyName;
            Formula = new Condition(
                text: text,
                checkbox: checkbox,
                number: number,
                date: date
            );
        }

        public class Condition
        {
            public TextFilter.Condition Text { get; set; }
            public CheckboxFilter.Condition Checkbox { get; set; }
            public NumberFilter.Condition Number { get; set; }
            public DateFilter.Condition Date { get; set; }

            public Condition(
                TextFilter.Condition text = null,
                CheckboxFilter.Condition checkbox = null,
                NumberFilter.Condition number = null,
                DateFilter.Condition date = null)
            {
                Text = text;
                Checkbox = checkbox;
                Number = number;
                Date = date;
            }
        }
    }
}
