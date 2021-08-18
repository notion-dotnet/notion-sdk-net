namespace Notion.Client
{
    public class SelectUpdatePropertySchema : IUpdatePropertySchema
    {
        public OptionWrapper<SelectOption> Select { get; set; }
    }
}
