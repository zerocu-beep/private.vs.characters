using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    public interface ISpatialHash
    {
        sealed Vector3 Position => ((Component) this).transform.position;

        sealed int UniqueCode => ((Component) this).transform.GetHashCode();
    }
}