using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    public readonly struct RotationNone : IRotation
    {
        public bool HasRotation(GameObject source) => false;
        
        public Quaternion GetRotation(GameObject source) => default;
    }
}