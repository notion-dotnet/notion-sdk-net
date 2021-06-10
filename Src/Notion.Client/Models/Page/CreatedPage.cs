using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Notion.Client
{
    [DataContract]
    public class CreatedPage
    {
        public CreatedPage(Parent parent)
        {
            Parent = parent;
            Properties = new Dictionary<string, PropertyValue>();
            Children = new List<Block>();
        }

        [DataMember]
        private Parent Parent;

        [DataMember]
        private Dictionary<string, PropertyValue> Properties;

        [DataMember]
        private List<Block> Children;

        public CreatedPage AddProperty(string nameOrId, PropertyValue value)
        {
            Properties[nameOrId] = value;
            return this;
        }

        public CreatedPage AddPageContent(Block block)
        {
            Children.Add(block);
            return this;
        }
    }
}
