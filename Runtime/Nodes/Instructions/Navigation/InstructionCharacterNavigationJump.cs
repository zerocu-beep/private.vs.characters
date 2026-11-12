using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Jump")]
    [Description("Instructs the Character to jump")]

    [Category("Characters/Navigation/Jump")]
    
    [Keywords("Hop", "Leap", "Reach")]
    [Image(typeof(IconCharacterJump), ColorTheme.Type.Blue)]

    [Serializable]
    public class InstructionCharacterNavigationJump : TInstructionCharacterNavigation
    {
        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Jump {this.m_Character}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            character.Jump.Do();
            return Done;
        }
    }
}