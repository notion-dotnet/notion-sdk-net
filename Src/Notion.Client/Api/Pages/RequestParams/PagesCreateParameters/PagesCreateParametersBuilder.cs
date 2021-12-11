using System.Collections.Generic;

namespace Notion.Client
{
    public class PagesCreateParametersBuilder
    {
        private IPageParentInput parent;
        private readonly Dictionary<string, PropertyValue> properties = new Dictionary<string, PropertyValue>();
        private readonly IList<IBlock> children = new List<IBlock>();
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

        public PagesCreateParametersBuilder AddProperty(string nameOrId, PropertyValue value)
        {
            properties[nameOrId] = value;
            return this;
        }

        public PagesCreateParametersBuilder AddPageContent(IBlock block)
        {
            children.Add(block);
            return this;
        }

        public PagesCreateParametersBuilder SetIcon(IPageIcon pageIcon)
        {
            icon = pageIcon;
            return this;
        }

        public PagesCreateParametersBuilder SetCover(FileObject pageCover)
        {
            cover = pageCover;
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
