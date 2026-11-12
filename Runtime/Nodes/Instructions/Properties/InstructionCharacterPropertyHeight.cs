using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Change Height")]
    [Description("Changes the Character's height over time")]

    [Category("Characters/Properties/Change Height")]
    
    [Parameter("Height", "The target Height value for the Character")]
    [Parameter("Duration", "How long it takes to perform the transition")]
    [Parameter("Easing", "The change rate of the parameter over time")]
    [Parameter("Wait to Complete", "Whether to wait until the transition is finished")]

    [Keywords("Length")]
    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterPropertyHeight : TInstructionCharacterProperty
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private GetNumber m_Height = new GetNumber(2f);
        [SerializeField] private TweenTransition m_Transition = new TweenTransition();
        
        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Height {this.m_Character} = {this.m_Height}{this.m_Transition}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override async Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return;

            float valueSource = character.Motion.Height;
            float valueTarget = (float) this.m_Height.Get(args);

            await CharacterTween.Run(
                character,
                "property:height",
                valueSource,
                valueTarget,
                value => character.Motion.Height = value,
                this.m_Transition,
                args
            );
        }
    }
}