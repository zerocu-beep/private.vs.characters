using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Change Radius")]
    [Description("Changes the Character's radius over time")]

    [Category("Characters/Properties/Change Radius")]
    
    [Parameter("Radius", "The target Radius value for the Character")]
    [Parameter("Duration", "How long it takes to perform the transition")]
    [Parameter("Easing", "The change rate of the parameter over time")]
    [Parameter("Wait to Complete", "Whether to wait until the transition is finished")]

    [Keywords("Diameter", "Space", "Fat", "Thin")]
    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterPropertyRadius : TInstructionCharacterProperty
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private GetNumber m_Radius = new GetNumber(0.5f);
        [SerializeField] private TweenTransition m_Transition = new TweenTransition();
        
        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Radius {this.m_Character} = {this.m_Radius}{this.m_Transition}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override async Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return;

            float valueSource = character.Motion.Radius;
            float valueTarget = (float) this.m_Radius.Get(args);

            await CharacterTween.Run(
                character,
                "property:radius",
                valueSource,
                valueTarget,
                value => character.Motion.Radius = value,
                this.m_Transition,
                args
            );
        }
    }
}