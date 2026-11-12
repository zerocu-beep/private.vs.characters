using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Enable Look")]
    [Category("Cameras/Shots/Look/Enable Look")]
    [Description("Toggles the active state of a Camera Shot's Look system")]

    [Parameter("Active", "The next state")]
    [Keywords("Cameras", "Disable", "Activate", "Deactivate", "Bool", "Toggle", "Off", "On")]

    [Serializable]
    public class InstructionShotLookEnable : TInstructionShotLook
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private GetBool m_Active = new GetBool(true);

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot}[Look] to {this.m_Active}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemLook shotSystem = this.GetShotSystem<ShotSystemLook>(args);
            
            if (shotSystem == null) return Done;
            shotSystem.IsActive = this.m_Active.Get(args);
            
            return Done;
        }
    }
}