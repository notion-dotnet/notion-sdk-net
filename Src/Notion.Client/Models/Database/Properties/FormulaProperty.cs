namespace Notion.Client
{
    public class FormulaProperty : Property
    {
        public override PropertyType Type => PropertyType.Formula;

        public Formula Formula { get; set; }
    }

    public class Formula
    {
        public string Expression { get; set; }
    }
}
