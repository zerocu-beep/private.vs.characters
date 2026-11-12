using System;

namespace VisualScript.Runtime.Characters
{
    public interface IMunition : ICloneable
    {
        int Id { get; }
        TMunitionValue Value { get; }
    }
}