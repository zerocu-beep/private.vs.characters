using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Add Target Candidate")]
    [Description("Adds a new candidate target for the specified character")]

    [Category("Characters/Combat/Targeting/Add Target Candidate")]
    
    [Parameter("Character", "The Character that attempts to change its candidate target")]
    [Parameter("Target", "The new target candidate game object by the character")]

    [Keywords("Character", "Combat", "Focus", "Pick")]
    [Image(typeof(IconBullsEye), ColorTheme.Type.TextLight, typeof(BadgePlus))]

    [Serializable]
    public class InstructionCharacterAddCandidateTarget : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        [SerializeField] private GetGameObject m_Target = new GetGameObject(new TypeGameObjectInstance());

        protected override string GetTitle(GameObject source) => $"Add {this.m_Target} Candidate to {this.m_Character}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            GameObject target = this.m_Target.Get(args);
            character.Combat.Targets.AddCandidate(target);
            
            return Done;
        }
    }
}