using UnityEngine;
using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Is Invincible")]
    [Description("Returns true if the Character is Invincible")]

    [Category("Characters/Combat/Is Invincible")]

    [Keywords("Invincibility", "Combat")]
    
    [Image(typeof(IconDiamondSolid), ColorTheme.Type.Yellow)]
    
    [Serializable]
    public class ConditionCharacterIsInvincible : TConditionCharacter
    {
        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"is Invincible {this.m_Character}";
        
        // RUN METHOD: ----------------------------------------------------------------------------

        protected override bool Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null && character.Combat.Invincibility.IsInvincible;
        }
    }
}
