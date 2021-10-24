using System.Collections.Generic;

namespace Notion.Client
{
    public class PagesCreateParametersBuilder
    {
        private IPageParentInput parent;
        private Dictionary<string, PropertyInputValue> properties = new Dictionary<string, PropertyInputValue>();
        private IList<Block> children = new List<Block>();
        private IPageIcon icon;
        private FileObject cover;

        private PagesCreateParametersBuilder()
        {
        }

        public static PagesCreateParametersBuilder Create(IPageParentInput parent)
        {
            return new PagesCreateParametersBuilder
            {
                parent = parent
            };
        }

        public PagesCreateParametersBuilder AddProperty(string nameOrId, PropertyInputValue value)
        {
            properties[nameOrId] = value;
            return this;
        }

        public PagesCreateParametersBuilder AddPageContent(Block block)
        {
            children.Add(block);
            return this;
        }

        public PagesCreateParameters Build()
        {
            return new PagesCreateParameters
            {
                Parent = parent,
                Properties = properties,
                Children = children,
                Icon = icon,
                Cover = cover
            };
        }
    }
}
