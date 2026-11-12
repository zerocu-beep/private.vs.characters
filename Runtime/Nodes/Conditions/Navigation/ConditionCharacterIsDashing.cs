using UnityEngine;
using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Is Dashing")]
    [Description("Returns true if the Character is dashing")]

    [Category("Characters/Navigation/Is Dashing")]

    [Keywords("Leap", "Blink", "Roll", "Flash")]
    
    [Image(typeof(IconCharacterDash), ColorTheme.Type.Yellow)]
    [Serializable]
    public class ConditionCharacterIsDashing : TConditionCharacter
    {
        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"is Dashing {this.m_Character}";
        
        // RUN METHOD: ----------------------------------------------------------------------------

        protected override bool Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null && character.Dash.IsDashing;
        }
    }
}
