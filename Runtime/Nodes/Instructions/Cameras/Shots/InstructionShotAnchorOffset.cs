using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Change Offset")]
    [Category("Cameras/Shots/Anchor/Change Offset")]
    [Description("Changes the offset position of the targeted object")]

    [Parameter("Offset", "The new offset in target local coordinates")]
    [Keywords("Cameras", "Track", "View")]

    [Serializable]
    public class InstructionShotAnchorOffset : TInstructionShotAnchor
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetVector3 m_Offset = new GetVector3();

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot}[Anchor] Offset = {this.m_Offset}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemAnchor shotSystem = this.GetShotSystem<ShotSystemAnchor>(args);
            
            if (shotSystem == null) return Done;
            shotSystem.Offset = this.m_Offset.Get(args);
            
            return Done;
        }
    }
}