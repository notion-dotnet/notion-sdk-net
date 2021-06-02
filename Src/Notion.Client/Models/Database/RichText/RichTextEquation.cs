namespace Notion.Client
{
    public class RichTextEquation : RichTextBase
    {
        public override RichTextType Type => RichTextType.Equation;
        public Equation Equation { get; set; }
    }

    public class Equation
    {
        public string Expression { get; set; }
    }
}
