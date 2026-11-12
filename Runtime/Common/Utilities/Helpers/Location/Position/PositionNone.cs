using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    public readonly struct PositionNone : IPosition
    {
        public bool HasPosition(GameObject user) => false;
        
        public Vector3 GetPosition(GameObject source) => default;
    }
}