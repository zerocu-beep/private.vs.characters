using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Set Character Rotation")]
    [Description("Changes the rotation behavior of the Character")]

    [Category("Characters/Navigation/Set Character Rotation")]

    [Parameter("Character", "The Character that changes its Rotation behavior")]
    [Parameter("Rotation", "The Rotation behavior that decides where the Character faces")]

    [Keywords("Character", "Face", "Look", "Direction", "Pivot", "Lock")]
    [Image(typeof(IconRotationYaw), ColorTheme.Type.Green)]

    [Serializable]
    public class InstructionCharacterNavigationFacing : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        [SerializeField] private UnitFacing m_Rotation = new UnitFacing();

        protected override string GetTitle(GameObject source) => 
            $"Change Rotation on {this.m_Character} to {this.m_Rotation}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            if (this.m_Rotation.Wrapper.GetType() != character.Facing.GetType())
            {
                character.Kernel.ChangeFacing(character, this.m_Rotation.Wrapper);
            }

            return Done;
        }
    }
}