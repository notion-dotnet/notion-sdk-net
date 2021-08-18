namespace Notion.Client
{
    public class RichTextEquationInput : RichTextBaseInput
    {
        public override RichTextType Type => RichTextType.Equation;
        public Equation Equation { get; set; }
    }
}
