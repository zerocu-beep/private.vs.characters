using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Change Movement Speed")]
    [Description("Changes the Character's maximum speed over time")]

    [Category("Characters/Properties/Change Movement Speed")]
    
    [Parameter("Speed", "The target movement Speed value for the Character")]
    [Parameter("Duration", "How long it takes to perform the transition")]
    [Parameter("Easing", "The change rate of the parameter over time")]
    [Parameter("Wait to Complete", "Whether to wait until the transition is finished")]

    [Keywords("Linear", "Walk", "Run", "Jog", "Sprint", "Velocity", "Throttle")]
    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterPropertyMoveSpeed : TInstructionCharacterProperty
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private GetNumber m_Speed = new GetNumber(4f);
        [SerializeField] private TweenTransition m_Transition = new TweenTransition();
        
        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Move Speed {this.m_Character} = {this.m_Speed}{this.m_Transition}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override async Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return;

            float valueSource = character.Motion.LinearSpeed;
            float valueTarget = (float) this.m_Speed.Get(args);

            await CharacterTween.Run(
                character,
                "property:linear-speed",
                valueSource,
                valueTarget,
                value => character.Motion.LinearSpeed = value,
                this.m_Transition,
                args
            );
        }
    }
}