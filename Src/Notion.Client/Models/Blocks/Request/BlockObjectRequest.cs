using System;

namespace Notion.Client
{
    public abstract class BlockObjectRequest : IBlockObjectRequest
    {
        public ObjectType Object => ObjectType.Block;

        public string Id { get; set; }

        public virtual BlockType Type { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime LastEditedTime { get; set; }

        public virtual bool HasChildren { get; set; }

        public PartialUser CreatedBy { get; set; }

        public PartialUser LastEditedBy { get; set; }

        /// <summary>
        ///     Information about the block's parent.
        /// </summary>
        public IBlockParent Parent { get; set; }
    }
}
