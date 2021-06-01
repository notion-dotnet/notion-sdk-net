namespace Notion.Client
{
    public class FormulaFilter : SinglePropertyFilter
    {
        public FormulaFilterCondition Formula { get; set; }
    }

    public class FormulaFilterCondition
    {
        public TextFilterCondition Text { get; set; }
        public CheckboxFilterCondition Checkbox { get; set; }
        public NumberFilterCondition Number { get; set; }
        public DateFilterCondition Date { get; set; }
    }
}