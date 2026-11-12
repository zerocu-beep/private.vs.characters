using UnityEngine;
using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Is Humanoid")]
    [Description("Returns true if the Character has a humanoid model")]

    [Category("Characters/Busy/Is Humanoid")]

    [Keywords("Human", "Biped")]
    
    [Image(typeof(IconCharacter), ColorTheme.Type.Green)]
    
    [Serializable]
    public class ConditionCharacterIsHumanoid : TConditionCharacter
    {
        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"is Humanoid {this.m_Character}";
        
        // RUN METHOD: ----------------------------------------------------------------------------

        protected override bool Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null && character.Animim.Animator.isHuman;
        }
    }
}
