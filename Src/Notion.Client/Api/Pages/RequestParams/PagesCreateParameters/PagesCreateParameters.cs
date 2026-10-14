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

        public string Markdown { get; set; }

        public PageTemplate Template { get; set; }

        public PagePosition Position { get; set; }

        /// <summary>
        /// Limits the returned page properties to the given property ids (sent as the
        /// <c>filter_properties</c> query parameter, not in the body).
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public IEnumerable<string> FilterProperties { get; set; }
    }
}
