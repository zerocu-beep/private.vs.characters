using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Change Distance")]
    [Category("Cameras/Shots/Anchor/Change Distance")]
    [Description("Changes the anchored position the Shot sits relative to the target")]

    [Parameter("Distance", "The new distance relative to the target in local coordinates")]
    [Keywords("Cameras", "View")]

    [Serializable]
    public class InstructionShotAnchorDistance : TInstructionShotAnchor
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetVector3 m_Distance = new GetVector3();

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot}[Anchor] Distance = {this.m_Distance}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemAnchor shotSystem = this.GetShotSystem<ShotSystemAnchor>(args);
            
            if (shotSystem == null) return Done;
            shotSystem.Distance = this.m_Distance.Get(args);
            
            return Done;
        }
    }
}