using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Change Level Zoom")]
    [Category("Cameras/Shots/Zoom/Change Level Zoom")]
    [Description("Changes the targeted zoom level percentage")]

    [Parameter("Level", "The zoom level value between zero and one")]

    [Serializable]
    public class InstructionShotZoomValue : TInstructionShotZoom
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetNumber m_Level = new GetNumber(0.5f);

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot}[Zoom] Level = {this.m_Level}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemZoom shotSystem = this.GetShotSystem<ShotSystemZoom>(args);
            
            if (shotSystem == null) return Done;
            shotSystem.Level = (float) this.m_Level.Get(args);
            
            return Done;
        }
    }
}