using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    using VisualScript.Runtime.Characters;


    [Title("Change Target")]
    [Category("Cameras/Shots/First Person/Change Target")]
    [Description("Changes the targeted game object to view from")]

    [Parameter("Target", "The new target")]
    [Keywords("Cameras", "Track", "View")]

    [Serializable]
    public class InstructionShotFirstPersonTarget : TInstructionShotFirstPerson
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetGameObject m_Target = new GetGameObject(new TypeGameObjectPlayer());

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot}[First Person] Target = {this.m_Target}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemFirstPerson shotSystem = this.GetShotSystem<ShotSystemFirstPerson>(args);
            
            if (shotSystem == null) return Done;
            shotSystem.Target = this.m_Target.Get(args);
            
            return Done;
        }
    }
}