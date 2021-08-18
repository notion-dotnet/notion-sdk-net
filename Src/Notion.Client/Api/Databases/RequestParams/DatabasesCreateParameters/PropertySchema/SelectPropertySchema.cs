namespace Notion.Client
{
    public class SelectPropertySchema : IPropertySchema
    {
        public OptionWrapper<SelectOptionSchema> Select { get; set; }
    }
}
