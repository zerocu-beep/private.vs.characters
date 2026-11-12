using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Image(typeof(IconBoneOutline), ColorTheme.Type.Green)]
    [Serializable]
    public class Footstep : TPolymorphicItem<Footstep>
    {
        [SerializeField] private Bone m_Bone;

        // PROPERTIES: ----------------------------------------------------------------------------

        public Bone Bone => this.m_Bone;

        public override string Title => $"{this.m_Bone}";
        
        // CONSTRUCTORS: --------------------------------------------------------------------------
        
        public Footstep()
        { }

        public Footstep(HumanBodyBones bone)
        {
            this.m_Bone = new Bone(bone);
        }

        public Footstep(string bonePath)
        {
            this.m_Bone = new Bone(bonePath);
        }
    }
}