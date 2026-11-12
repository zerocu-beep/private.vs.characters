using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Change Distance")]
    [Category("Cameras/Shots/Lock On/Change Distance")]
    [Description("Changes the distance from the anchor point")]

    [Parameter("Distance", "The new distance in self local coordinates")]
    [Keywords("Cameras", "Track", "View")]

    [Serializable]
    public class InstructionShotLockOnDistance : TInstructionShotLockOn
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetNumber m_Distance = new GetNumber(5f);

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot}[Lock On] Distance = {this.m_Distance}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemLockOn shotSystem = this.GetShotSystem<ShotSystemLockOn>(args);
            
            if (shotSystem == null) return Done;
            shotSystem.Distance = (float) this.m_Distance.Get(args);
            
            return Done;
        }
    }
}