using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Remove Target Candidate")]
    [Description("Removes a new candidate target for the specified character")]

    [Category("Characters/Combat/Targeting/Remove Target Candidate")]
    
    [Parameter("Character", "The Character that attempts to change its target candidate")]
    [Parameter("Target", "The target candidate to remove by the character")]

    [Keywords("Character", "Combat", "Focus", "Pick")]
    [Image(typeof(IconBullsEye), ColorTheme.Type.TextLight, typeof(BadgeMinus))]

    [Serializable]
    public class InstructionCharacterRemoveCandidateTarget : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        [SerializeField] private GetGameObject m_Target = new GetGameObject(new TypeGameObjectInstance());

        protected override string GetTitle(GameObject source) => $"Remove {this.m_Target} Candidate from {this.m_Character}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            GameObject target = this.m_Target.Get(args);
            character.Combat.Targets.RemoveCandidate(target);
            
            return Done;
        }
    }
}