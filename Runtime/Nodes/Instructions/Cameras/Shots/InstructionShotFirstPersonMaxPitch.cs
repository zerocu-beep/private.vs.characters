using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Change Max Pitch")]
    [Category("Cameras/Shots/First Person/Change Max Pitch")]
    [Description("Changes the maximum rotation (up and down) allowed")]

    [Parameter("Max Pitch", "The amount the Shot is allowed to look up and down, in degrees")]

    [Serializable]
    public class InstructionShotFirstPersonMaxPitch : TInstructionShotFirstPerson
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetNumber m_MaxPitch = new GetNumber(60f);

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot}[First Person] Max Pitch = {this.m_MaxPitch}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemFirstPerson shotSystem = this.GetShotSystem<ShotSystemFirstPerson>(args);
            
            if (shotSystem == null) return Done;
            shotSystem.MaxPitch = (float) this.m_MaxPitch.Get(args);
            
            return Done;
        }
    }
}