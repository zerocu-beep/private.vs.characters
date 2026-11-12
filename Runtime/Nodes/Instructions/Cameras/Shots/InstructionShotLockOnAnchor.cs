using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    using VisualScript.Runtime.Characters;


    [Title("Change Anchor")]
    [Category("Cameras/Shots/Lock On/Change Anchor")]
    [Description("Changes the targeted game object to Lock On")]

    [Parameter("Anchor", "The new target to Anchor onto")]
    [Keywords("Cameras", "Track", "View")]

    [Serializable]
    public class InstructionShotLockOnAnchor : TInstructionShotLockOn
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetGameObject m_Anchor = new GetGameObject(new TypeGameObjectPlayer());

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot}[Lock On] Anchor = {this.m_Anchor}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemLockOn shotSystem = this.GetShotSystem<ShotSystemLockOn>(args);
            
            if (shotSystem == null) return Done;
            shotSystem.Anchor = this.m_Anchor.Get(args);
            
            return Done;
        }
    }
}