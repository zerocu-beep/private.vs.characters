using System;

namespace VisualScript.Runtime.Characters
{
    public class Footprint
    {
        [field: NonSerialized] public bool WasGrounded { get; set; } = true;
    }
}