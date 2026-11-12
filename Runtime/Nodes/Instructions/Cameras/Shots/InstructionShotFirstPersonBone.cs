using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    using VisualScript.Runtime.Characters;


    [Title("Change Bone")]
    [Category("Cameras/Shots/First Person/Change Bone")]
    [Description("Changes the Bone mount of the targeted object")]

    [Parameter("Bone", "The new bone of the character")]

    [Serializable]
    public class InstructionShotFirstPersonBone : TInstructionShotFirstPerson
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private Bone m_Bone = new Bone(HumanBodyBones.Head);

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot} = {this.m_Bone}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemFirstPerson shotSystem = this.GetShotSystem<ShotSystemFirstPerson>(args);
            
            if (shotSystem == null) return Done;
            shotSystem.Bone = this.m_Bone;
            
            return Done;
        }
    }
}