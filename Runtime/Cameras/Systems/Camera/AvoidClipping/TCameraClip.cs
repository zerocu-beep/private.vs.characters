using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Avoid Clipping")]
    [System.Serializable]
    public abstract class TCameraClip
    {
        public abstract Vector3 Update(TCamera camera, Vector3 point, Transform[] ignore);
        
        public abstract void OnDrawGizmos(TCamera camera);
    }
}