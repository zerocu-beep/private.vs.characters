using UnityEngine;
using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Reset Vertical Velocity")]
    [Description("Changes the Character's vertical velocity to zero")]

    [Category("Characters/Properties/Reset Vertical Velocity")]

    [Keywords("Fall", "Speed")]
    [Image(typeof(IconFall), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterResetVerticalVelocity : TInstructionCharacterProperty
    {
        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Reset {m_Character} Vertical Velocity";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character != null) character.Driver.ResetVerticalVelocity();
            
            return Done;
        }
    }
}