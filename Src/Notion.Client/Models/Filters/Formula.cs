namespace Notion.Client
{
    public class FormulaFilter : SinglePropertyFilter
    {
        public TextFilter Text { get; set; }
        public CheckboxFilter checkbox { get; set; }
        public NumberFilter number { get; set; }
        public DateFilter date { get; set; }
    }
}