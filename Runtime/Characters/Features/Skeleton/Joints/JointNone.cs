using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("No Joint")]
    [Category("No Joint")]
    
    [Image(typeof(IconEmpty), ColorTheme.Type.TextNormal)]
    [Description("Do not use any Joint")]
    
    [Serializable]
    public class JointNone : IJoint
    {
        // PUBLIC METHODS: ------------------------------------------------------------------------
        
        public Joint Setup(GameObject gameObject, Skeleton skeleton, Animator animator)
        {
            return null;
        }

        public override string ToString()
        {
            return "no joint";
        }
    }
}