using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Change Smooth Time")]
    [Category("Cameras/Shots/Zoom/Change Smooth Time")]
    [Description("Changes how smooth the zoom responds to input")]

    [Parameter("Smooth Time", "How smooth is the zoom transition")]

    [Serializable]
    public class InstructionShotZoomSmoothTime : TInstructionShotZoom
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetNumber m_SmoothTime = new GetNumber(0.1f);

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot}[Zoom] Smooth Time = {this.m_SmoothTime}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemZoom shotSystem = this.GetShotSystem<ShotSystemZoom>(args);
            
            if (shotSystem == null) return Done;
            shotSystem.SmoothTime = (float) this.m_SmoothTime.Get(args);
            
            return Done;
        }
    }
}