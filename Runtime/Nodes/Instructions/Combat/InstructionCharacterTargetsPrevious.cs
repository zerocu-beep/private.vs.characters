using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Cycle Previous Target")]
    [Description("Cycles to the previous candidate target from the Targets list")]

    [Category("Characters/Combat/Targeting/Cycle Previous Target")]
    
    [Parameter("Character", "The Character that attempts to change its candidate target")]

    [Keywords("Character", "Combat", "Focus", "Pick", "Candidate", "Targets")]
    [Image(typeof(IconBullsEye), ColorTheme.Type.Yellow, typeof(BadgeArrowLeft))]

    [Serializable]
    public class InstructionCharacterTargetsPrevious : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        protected override string GetTitle(GameObject source) => $"Cycle Previous Target from {this.m_Character}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            CycleTargets.Previous(character);
            return Done;
        }
    }
}