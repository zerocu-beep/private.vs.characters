using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Joint Type")]
    
    public interface IJoint
    {
        Joint Setup(GameObject gameObject, Skeleton skeleton, Animator animator);
    }
}