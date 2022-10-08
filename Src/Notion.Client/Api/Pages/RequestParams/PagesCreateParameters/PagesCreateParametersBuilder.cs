﻿using System.Collections.Generic;

namespace Notion.Client
{
    public class PagesCreateParametersBuilder
    {
        private readonly IList<IBlock> children = new List<IBlock>();
        private readonly Dictionary<string, PropertyValue> properties = new();
        private FileObject cover;
        private IPageIcon icon;
        private IPageParentInput parent;

        private PagesCreateParametersBuilder()
        {
        }

        public static PagesCreateParametersBuilder Create(IPageParentInput parent)
        {
            return new PagesCreateParametersBuilder { parent = parent };
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
