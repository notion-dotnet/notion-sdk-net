using System.Collections.Generic;

namespace Notion.Client
{
    public class PagesCreateParameters : IPagesCreateBodyParameters, IPagesCreateQueryParameters
    {
        public IParentOfPageRequest Parent { get; set; }

        public IDictionary<string, PropertyValue> Properties { get; set; }

        public IList<IBlock> Children { get; set; }

        public IPageIconRequest Icon { get; set; }

        public IPageCoverRequest Cover { get; set; }
    }
}
