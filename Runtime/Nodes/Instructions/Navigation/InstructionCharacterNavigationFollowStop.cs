using UnityEngine;
using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Stop Following")]
    [Description("Instructs a Character to stop following a game object")]

    [Category("Characters/Navigation/Stop Following")]

    [Keywords("Cancel", "Lead", "Pursue", "Chase")]
    [Image(typeof(IconCharacterIdle), ColorTheme.Type.Red)]

    [Serializable]
    public class InstructionCharacterNavigationFollowStop : TInstructionCharacterNavigation
    {
        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"{this.m_Character} Stop Following";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;
            
            character.Motion.StopFollowingTarget();
            return Done;
        }
    }
}