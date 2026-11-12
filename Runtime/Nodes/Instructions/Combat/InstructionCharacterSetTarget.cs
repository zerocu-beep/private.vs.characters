using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Set Target")]
    [Description("Changes the targeted game object by the specified Character")]

    [Category("Characters/Combat/Targeting/Set Target")]
    
    [Parameter("Character", "The Character that attempts to change its target")]
    [Parameter("Target", "The new targeted game object by the character")]

    [Keywords("Character", "Combat", "Focus", "Pick")]
    [Image(typeof(IconBullsEye), ColorTheme.Type.Green)]

    [Serializable]
    public class InstructionCharacterSetTarget : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        [SerializeField] private GetGameObject m_Target = new GetGameObject(new TypeGameObjectInstance());

        protected override string GetTitle(GameObject source) => $"Target {this.m_Character} = {this.m_Target}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            GameObject target = this.m_Target.Get(args);
            character.Combat.Targets.Primary = target;
            
            return Done;
        }
    }
}