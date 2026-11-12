using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Change Mass")]
    [Description("Changes the Character's mass over time")]

    [Category("Characters/Properties/Change Mass")]
    
    [Parameter("Mass", "The target Mass value for the Character")]
    [Parameter("Duration", "How long it takes to perform the transition")]
    [Parameter("Easing", "The change rate of the parameter over time")]
    [Parameter("Wait to Complete", "Whether to wait until the transition is finished")]

    [Keywords("Weight")]
    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterPropertyMass : TInstructionCharacterProperty
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private GetNumber m_Mass = new GetNumber(80f);
        [SerializeField] private TweenTransition m_Transition = new TweenTransition();
        
        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Mass of {this.m_Character} = {this.m_Mass}{this.m_Transition}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override async Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return;

            float valueSource = character.Motion.Mass;
            float valueTarget = (float) this.m_Mass.Get(args);

            await CharacterTween.Run(
                character,
                "property:mass",
                valueSource,
                valueTarget,
                value => character.Motion.Mass = value,
                this.m_Transition,
                args
            );
        }
    }
}