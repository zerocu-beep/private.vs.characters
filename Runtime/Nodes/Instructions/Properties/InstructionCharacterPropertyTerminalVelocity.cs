using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Change Terminal Velocity")]
    [Description("Changes the Character's maximum fall-speed over time. Useful for gliding")]

    [Category("Characters/Properties/Change Terminal Velocity")]
    
    [Parameter("Terminal Velocity", "The target Terminal Velocity value for the Character")]
    [Parameter("Duration", "How long it takes to perform the transition")]
    [Parameter("Easing", "The change rate of the parameter over time")]
    [Parameter("Wait to Complete", "Whether to wait until the transition is finished")]

    [Keywords("Fall", "Glide", "Parachute", "Height")]
    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterPropertyTerminalVelocity : TInstructionCharacterProperty
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private GetNumber m_TerminalVelocity = new GetNumber(-53f);
        [SerializeField] private TweenTransition m_Transition = new TweenTransition();
        
        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Terminal Velocity {this.m_Character} = {this.m_TerminalVelocity}{this.m_Transition}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override async Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return;

            float valueSource = Math.Min(0f, character.Driver.WorldMoveDirection.y);
            float valueTarget = (float) this.m_TerminalVelocity.Get(args);

            await CharacterTween.Run(
                character,
                "property:terminal-velocity",
                valueSource,
                valueTarget,
                value => character.Motion.TerminalVelocity = value,
                this.m_Transition,
                args
            );
        }
    }
}