using System.Collections.Generic;

namespace Notion.Client
{
    public class NewPage
    {
        /// <summary>
        /// Constructor without arguments: added for class initializations using class literals.
        /// </summary>
        public NewPage()
        {
            Properties = new Dictionary<string, PropertyValue>();
            Children = new List<Block>();
        }

        /// <summary>
        /// Constructor that adds required <c>Parent</c> property. Used when you don't want to
        /// assign properties in separate operations.
        /// </summary>
        public NewPage(Parent parent)
        {
            Parent = parent;
            Properties = new Dictionary<string, PropertyValue>();
            Children = new List<Block>();
        }

        public Parent Parent { get; set; }

        public Dictionary<string, PropertyValue> Properties { get; set; }

        public List<Block> Children { get; set; }

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
