using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Change Duration")]
    [Category("Cameras/Shots/Animation/Change Duration")]
    [Description("Changes the duration it takes for the Animation shot to complete")]

    [Parameter("Duration", "The new duration in seconds")]
    [Keywords("Cameras", "Track", "View")]

    [Serializable]
    public class InstructionShotAnimationDuration : TInstructionShotAnimation
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetNumber m_Duration = new GetNumber(5f);

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot}[Animation] Duration = {this.m_Duration}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemAnimation shotSystem = this.GetShotSystem<ShotSystemAnimation>(args);
            
            if (shotSystem == null) return Done;
            shotSystem.Duration = (float) this.m_Duration.Get(args);
            
            return Done;
        }
    }
}