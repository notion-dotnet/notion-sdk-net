using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class PagesCreateParametersBuilder
    {
        private readonly IList<IBlock> _children = new List<IBlock>();
        private readonly Dictionary<string, PropertyValue> _properties = new();
        private FileObject _cover;
        private IPageIcon _icon;
        private IPageParentInput _parent;

        private PagesCreateParametersBuilder()
        {
        }

        public static PagesCreateParametersBuilder Create(IPageParentInput parent)
        {
            return new PagesCreateParametersBuilder { _parent = parent };
        }

        public PagesCreateParametersBuilder AddProperty(string nameOrId, PropertyValue value)
        {
            _properties[nameOrId] = value;

            return this;
        }

        public PagesCreateParametersBuilder AddPageContent(IBlock block)
        {
            _children.Add(block);

            return this;
        }

        public PagesCreateParametersBuilder SetIcon(IPageIcon pageIcon)
        {
            _icon = pageIcon;

            return this;
        }

        public PagesCreateParametersBuilder SetCover(FileObject pageCover)
        {
            _cover = pageCover;

            return this;
        }

        public PagesCreateParameters Build()
        {
            return new PagesCreateParameters
            {
                Parent = _parent,
                Properties = _properties,
                Children = _children,
                Icon = _icon,
                Cover = _cover
            };
        }
    }
}
