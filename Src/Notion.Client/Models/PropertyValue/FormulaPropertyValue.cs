namespace Notion.Client
{
    public class FormulaPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Formula;

        public FormulaValue Formula { get; set; }
    }

    public class FormulaValue
    {
        public string Type { get; set; }
        public string String { get; set; }
        public double? Number { get; set; }
        public bool Boolean { get; set; }
        public DatePropertyValue Date { get; set; }
    }
}
