using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Set Player Input")]
    [Description("Changes how the Player Character reacts to input commands")]

    [Category("Characters/Player/Set Player Input")]
    
    [Parameter("Character", "The Character that changes its Player Input behavior")]
    [Parameter("Input", "The new input method that the Character starts to listen")]

    [Keywords("Character", "Button", "Control", "Keyboard", "Mouse", "Gamepad", "Joystick")]
    [Image(typeof(IconGamepadCross), ColorTheme.Type.Green)]

    [Serializable]
    public class InstructionCharacterPlayer : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        [SerializeField] private UnitPlayer m_Input = new UnitPlayer();

        protected override string GetTitle(GameObject source) => 
            $"Change Player Input on {this.m_Character} to {this.m_Input}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            character.Kernel.ChangePlayer(character, this.m_Input.Wrapper);
            return Done;
        }
    }
}