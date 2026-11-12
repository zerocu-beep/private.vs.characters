using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    using VisualScript.Runtime.Characters;


    [Title("Change Target")]
    [Category("Cameras/Shots/Follow/Change Target")]
    [Description("Changes the targeted game object to Follow")]

    [Parameter("Follow", "The new target to follow")]
    [Keywords("Cameras", "Track", "View")]

    [Serializable]
    public class InstructionShotFollowTarget : TInstructionShotFollow
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetGameObject m_Follow = new GetGameObject(new TypeGameObjectPlayer());

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot}[Follow] Follow = {this.m_Follow}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemFollow shotSystem = this.GetShotSystem<ShotSystemFollow>(args);
            
            if (shotSystem == null) return Done;
            shotSystem.Follow = this.m_Follow.Get<Transform>(args);
            
            return Done;
        }
    }
}