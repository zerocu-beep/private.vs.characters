using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Cycle Next Target")]
    [Description("Cycles to the next candidate target from the Targets list")]

    [Category("Characters/Combat/Targeting/Cycle Next Target")]
    
    [Parameter("Character", "The Character that attempts to change its candidate target")]

    [Keywords("Character", "Combat", "Focus", "Pick", "Candidate", "Targets")]
    [Image(typeof(IconBullsEye), ColorTheme.Type.Yellow, typeof(BadgeArrowRight))]

    [Serializable]
    public class InstructionCharacterTargetsNext : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        protected override string GetTitle(GameObject source) => $"Cycle Next Target from {this.m_Character}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            CycleTargets.Next(character);
            return Done;
        }
    }
}