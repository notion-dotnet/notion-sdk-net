using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class NewPage
    {
        /// <summary>
        /// Constructor that adds required <c>Parent</c> property. Used when you don't want to
        /// assign properties in separate operations.
        /// </summary>
        public NewPage(IPageParent parent)
        {
            Parent = parent;
            Properties = new Dictionary<string, PropertyValue>();
            Children = new List<Block>();
        }

        public IPageParent Parent { get; set; }

        public Dictionary<string, PropertyValue> Properties { get; set; }

        public List<Block> Children { get; set; }

        [JsonProperty("icon")]
        public IPageIcon Icon { get; set; }

        [JsonProperty("cover")]
        public FileObject Cover { get; set; }

        public NewPage AddProperty(string nameOrId, PropertyValue value)
        {
            Properties[nameOrId] = value;
            return this;
        }

        public NewPage AddPageContent(Block block)
        {
            Children.Add(block);
            return this;
        }
    }
}
