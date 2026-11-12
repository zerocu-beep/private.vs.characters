using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    public interface IPosition
    {
        bool HasPosition(GameObject user);
        Vector3 GetPosition(GameObject source);
    }
}