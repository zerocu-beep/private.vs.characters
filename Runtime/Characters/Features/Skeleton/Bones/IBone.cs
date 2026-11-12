using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Bone Type")]
    
    public interface IBone
    {
        Transform GetTransform(Animator animator);
    }
}