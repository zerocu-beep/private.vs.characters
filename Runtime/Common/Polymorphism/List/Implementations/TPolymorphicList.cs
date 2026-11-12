using System;

namespace VisualScript.Runtime.Characters
{
    [Serializable]
    public abstract class TPolymorphicList<TItem> : IPolymorphicList where TItem : IPolymorphicItem
    {
        public abstract int Length { get; }
    }
}
