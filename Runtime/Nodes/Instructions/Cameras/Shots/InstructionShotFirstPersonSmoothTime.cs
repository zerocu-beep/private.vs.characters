using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Change Smooth Time")]
    [Category("Cameras/Shots/First Person/Change Smooth Time")]
    [Description("Changes the maximum rotation (up and down) allowed")]

    [Parameter("Smooth Time", "How smooth the camera operates when rotating")]

    [Serializable]
    public class InstructionShotFirstPersonSmoothTime : TInstructionShotFirstPerson
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetNumber m_SmoothTime = new GetNumber(0.1f);

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot}[First Person] Smooth Time = {this.m_SmoothTime}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemFirstPerson shotSystem = this.GetShotSystem<ShotSystemFirstPerson>(args);
            
            if (shotSystem == null) return Done;
            shotSystem.SmoothTime = (float) this.m_SmoothTime.Get(args);
            
            return Done;
        }
    }
}