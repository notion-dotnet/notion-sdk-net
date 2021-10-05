using System.Collections.Generic;

namespace Notion.Client
{
    public class PagesCreateParametersBuilder
    {
        private IPageParent parent;
        private Dictionary<string, PropertyValue> properties = new Dictionary<string, PropertyValue>();
        private IList<Block> children = new List<Block>();
        private IPageIcon icon;
        private FileObject cover;

        private PagesCreateParametersBuilder()
        {
        }

        public static PagesCreateParametersBuilder Create(IPageParent parent)
        {
            return new PagesCreateParametersBuilder {
                parent = parent
            };
        }

        public PagesCreateParametersBuilder AddProperty(string nameOrId, PropertyValue value)
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
