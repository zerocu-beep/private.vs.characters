using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Enable Head Bobbing")]
    [Category("Cameras/Shots/Head Bobbing/Enable Head Bobbing")]
    [Description("Toggles the active state of a Camera Shot's Head Bobbing system")]

    [Parameter("Active", "The next state")]
    [Keywords("Cameras", "Disable", "Activate", "Deactivate", "Bool", "Toggle", "Off", "On")]

    [Serializable]
    public class InstructionShotHeadBobbingEnable : TInstructionShotHeadBobbing
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private GetBool m_Active = new GetBool(true);

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot}[Head Bobbing] to {this.m_Active}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemHeadBobbing shotSystem = this.GetShotSystem<ShotSystemHeadBobbing>(args);
            
            if (shotSystem == null) return Done;
            shotSystem.IsActive = this.m_Active.Get(args);
            
            return Done;
        }
    }
}