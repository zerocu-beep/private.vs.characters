using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Change Distance")]
    [Category("Cameras/Shots/Follow/Change Distance")]
    [Description("Changes the offset distance between the Shot and the targeted object")]

    [Parameter("Distance", "The new offset distance in world coordinates")]
    [Keywords("Cameras", "Track", "View")]

    [Serializable]
    public class InstructionShotFollowDistance : TInstructionShotFollow
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetVector3 m_Offset = new GetVector3();

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot}[Follow] Distance = {this.m_Offset}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemFollow shotSystem = this.GetShotSystem<ShotSystemFollow>(args);
            
            if (shotSystem == null) return Done;
            shotSystem.Distance = this.m_Offset.Get(args);
            
            return Done;
        }
    }
}