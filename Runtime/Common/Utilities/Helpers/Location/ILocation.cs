using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    public interface ILocation
    {
        bool HasPosition(GameObject source);
        bool HasRotation(GameObject source);

        Vector3 GetPosition(GameObject source);
        Quaternion GetRotation(GameObject source);
    }
}