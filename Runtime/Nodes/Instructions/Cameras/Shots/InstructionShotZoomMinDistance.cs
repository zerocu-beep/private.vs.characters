using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Change Min Distance")]
    [Category("Cameras/Shots/Zoom/Change Min Distance")]
    [Description("Changes the targeted zoom level percentage")]

    [Parameter("Min Distance", "The minimum zoom distance between the target and the Shot")]

    [Serializable]
    public class InstructionShotZoomMinDistance : TInstructionShotZoom
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetNumber m_MinDistance = new GetNumber(1f);

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot}[Zoom] Min Distance = {this.m_MinDistance}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemZoom shotSystem = this.GetShotSystem<ShotSystemZoom>(args);
            
            if (shotSystem == null) return Done;
            shotSystem.MinDistance = (float) this.m_MinDistance.Get(args);
            
            return Done;
        }
    }
}