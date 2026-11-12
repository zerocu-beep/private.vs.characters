using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Change Smooth Time")]
    [Description("Changes the average blend time between locomotion animations")]

    [Category("Characters/Animation/Change Smooth Time")]
    
    [Parameter("Smooth Time", "The target Smooth Time value. Values usually range between 0 and 0.5")]
    [Parameter("Duration", "How long it takes to perform the transition")]
    [Parameter("Easing", "The change rate of the parameter over time")]
    [Parameter("Wait to Complete", "Whether to wait until the transition is finished")]

    
    [Keywords("Fade", "Realistic", "Old", "School", "Reaction")]
    [Image(typeof(IconAnimator), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterSmoothTime : TInstructionCharacterProperty
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private GetNumber m_SmoothTime = new GetNumber(0.25f);
        [SerializeField] private TweenTransition m_Transition = new TweenTransition();
        
        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Change Smooth Time of {this.m_Character} = {this.m_SmoothTime}{this.m_Transition}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override async Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return;

            float valueSource = character.Animim.SmoothTime;
            float valueTarget = (float) this.m_SmoothTime.Get(args);

            await CharacterTween.Run(
                character,
                "smooth-time",
                valueSource,
                valueTarget,
                value => character.Animim.SmoothTime = value,
                this.m_Transition,
                args
            );
        }
    }
}