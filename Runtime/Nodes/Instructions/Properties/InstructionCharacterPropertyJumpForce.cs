using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Change Jump Force")]
    [Description("Changes the Character's jump force over time")]

    [Category("Characters/Properties/Change Jump Force")]
    
    [Parameter("Jump Force", "The target Jump Force value for the Character")]
    [Parameter("Duration", "How long it will take to perform the transition")]
    [Parameter("Easing", "The change rate of the parameter over time")]
    [Parameter("Wait to Complete", "Whether to wait until the transition is finished")]

    [Keywords("Hop", "Build", "Wind", "Fly")]
    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterPropertyJumpForce : TInstructionCharacterProperty
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private GetNumber m_JumpForce = new GetNumber(4f);
        [SerializeField] private TweenTransition m_Transition = new TweenTransition();
        
        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Jump Force {this.m_Character} = {this.m_JumpForce}{this.m_Transition}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override async Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return;

            float valueSource = character.Motion.JumpForce;
            float valueTarget = (float) this.m_JumpForce.Get(args);

            await CharacterTween.Run(
                character,
                "property:jump-force",
                valueSource,
                valueTarget,
                value => character.Motion.JumpForce = value,
                this.m_Transition,
                args
            );
        }
    }
}