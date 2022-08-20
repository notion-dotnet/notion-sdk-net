using System;

namespace Notion.Client
{
    public abstract class Block : IBlock
    {
        public ObjectType Object => ObjectType.Block;

        public string Id { get; set; }

        public virtual BlockType Type { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime LastEditedTime { get; set; }

        public virtual bool HasChildren { get; set; }
    }
}
