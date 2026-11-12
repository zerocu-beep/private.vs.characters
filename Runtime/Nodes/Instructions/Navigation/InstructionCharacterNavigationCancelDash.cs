using UnityEngine;
using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Cancel Dash")]
    [Description("Cancels any existing Dash on the chosen Character")]

    [Category("Characters/Navigation/Cancel Dash")]

    [Keywords("Leap", "Blink", "Roll", "Flash")]
    [Image(typeof(IconCharacterDash), ColorTheme.Type.TextLight, typeof(BadgeCross))]

    [Serializable]
    public class InstructionCharacterNavigationCancelDash : TInstructionCharacterNavigation
    {
        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Cancel Dash on {this.m_Character}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            character.Dash.Cancel();
            return Done;
        }
    }
}