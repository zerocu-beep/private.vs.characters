using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Interact")]
    [Description("Changes how the Player Character reacts to input commands")]

    [Category("Characters/Interaction/Interact")]
    
    [Parameter("Character", "The Character that attempts to interact")]

    [Keywords("Character", "Button", "Pick", "Do", "Use", "Pull", "Press", "Push", "Talk")]
    [Image(typeof(IconCharacterInteract), ColorTheme.Type.Green)]

    [Serializable]
    public class InstructionCharacterInteract : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        protected override string GetTitle(GameObject source) => $"{this.m_Character} do Interact";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            character.Interaction.Interact();
            return Done;
        }
    }
}