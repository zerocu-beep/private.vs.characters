using UnityEngine;
using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Is Grounded")]
    [Description("Returns true if the Character touching the floor")]

    [Category("Characters/Navigation/Is Grounded")]

    [Keywords("Floor", "Stand", "Land")]
    
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Yellow, typeof(BadgeBar))]
    [Serializable]
    public class ConditionCharacterIsGrounded : TConditionCharacter
    {
        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"is Grounded {this.m_Character}";
        
        // RUN METHOD: ----------------------------------------------------------------------------

        protected override bool Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null && character.Driver.IsGrounded;
        }
    }
}
