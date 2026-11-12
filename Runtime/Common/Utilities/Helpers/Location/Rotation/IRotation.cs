using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    public interface IRotation
    {
        bool HasRotation(GameObject source);
        Quaternion GetRotation(GameObject source);
    }
}