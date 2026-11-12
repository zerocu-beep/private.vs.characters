using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Clear Target")]
    [Description("Clears the targeted game object by the specified Character")]

    [Category("Characters/Combat/Targeting/Clear Target")]
    
    [Parameter("Character", "The Character that attempts to change its target")]

    [Keywords("Character", "Combat", "Focus", "Pick")]
    [Image(typeof(IconBullsEye), ColorTheme.Type.Red)]

    [Serializable]
    public class InstructionCharacterClearTarget : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        protected override string GetTitle(GameObject source) => $"Target {this.m_Character} = none";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;
            
            character.Combat.Targets.Primary = null;
            return Done;
        }
    }
}