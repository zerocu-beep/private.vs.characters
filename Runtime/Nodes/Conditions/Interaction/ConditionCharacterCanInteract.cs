using UnityEngine;
using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Can Interact")]
    [Description("Returns true if the Character has any interactive element available")]

    [Category("Characters/Interaction/Can Interact")]

    [Keywords("Character", "Button", "Pick", "Do", "Use", "Pull", "Press", "Push", "Talk")]
    
    [Image(typeof(IconCharacterInteract), ColorTheme.Type.Green)]
    
    [Serializable]
    public class ConditionCharacterCanInteract : TConditionCharacter
    {
        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"can {this.m_Character} Interact";
        
        // RUN METHOD: ----------------------------------------------------------------------------

        protected override bool Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null && character.Interaction.CanInteract;
        }
    }
}
