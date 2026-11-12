using UnityEngine;
using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Is Controllable")]
    [Description("Returns true if the Player unit of the Character is controllable")]

    [Category("Characters/Properties/Is Controllable")]

    [Keywords("Control", "Character", "Player")]
    
    [Image(typeof(IconBust), ColorTheme.Type.Green)]
    [Serializable]
    public class ConditionCharacterIsControllable : TConditionCharacter
    {
        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"is {this.m_Character} Controllable";
        
        // RUN METHOD: ----------------------------------------------------------------------------

        protected override bool Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null && character.Player.IsControllable;
        }
    }
}
