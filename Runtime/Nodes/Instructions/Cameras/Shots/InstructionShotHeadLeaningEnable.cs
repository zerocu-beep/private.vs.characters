using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Enable Head Leaning")]
    [Category("Cameras/Shots/Head Leaning/Enable Head Leaning")]
    [Description("Toggles the active state of a Camera Shot's Head Leaning system")]

    [Parameter("Active", "The next state")]
    [Keywords("Cameras", "Disable", "Activate", "Deactivate", "Bool", "Toggle", "Off", "On")]

    [Serializable]
    public class InstructionShotHeadLeaningEnable : TInstructionShotHeadLeaning
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private GetBool m_Active = new GetBool(true);

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot}[Head Leaning] to {this.m_Active}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemHeadLeaning shotSystem = this.GetShotSystem<ShotSystemHeadLeaning>(args);
            
            if (shotSystem == null) return Done;
            shotSystem.IsActive = this.m_Active.Get(args);
            
            return Done;
        }
    }
}