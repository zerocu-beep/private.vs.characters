using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Change Sensitivity")]
    [Category("Cameras/Shots/First Person/Change Sensitivity")]
    [Description("Changes how sensitive the Shot reacts to input")]

    [Parameter("Sensitivity", "Input sensitivity for X and the Y axis")]

    [Serializable]
    public class InstructionShotFirstPersonSensitivity : TInstructionShotFirstPerson
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField]
        private GetVector3 m_Sensitivity = new GetVector3(new Vector3(180f, 180f));

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot}[First Person] Sensitivity = {this.m_Sensitivity}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemFirstPerson shotSystem = this.GetShotSystem<ShotSystemFirstPerson>(args);
            
            if (shotSystem == null) return Done;
            shotSystem.Sensitivity = this.m_Sensitivity.Get(args);
            
            return Done;
        }
    }
}