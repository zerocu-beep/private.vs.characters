using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Change Angular Speed")]
    [Description("Changes the Character's angular speed over time")]

    [Category("Characters/Properties/Change Angular Speed")]
    
    [Parameter("Angular Speed", "The target Angular Speed value for the Character, measured in degrees per second")]
    [Parameter("Duration", "How long it takes to perform the transition")]
    [Parameter("Easing", "The change rate of the parameter over time")]
    [Parameter("Wait to Complete", "Whether to wait until the transition is finished")]

    [Keywords("Rotation", "Euler", "Direction", "Face", "Look")]
    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterPropertyAngularSpeed : TInstructionCharacterProperty
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private GetNumber m_AngularSpeed = new GetNumber(720f);
        [SerializeField] private TweenTransition m_Transition = new TweenTransition();
        
        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => 
            $"Angular Speed {this.m_Character} = {this.m_AngularSpeed}{this.m_Transition}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override async Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return;

            float valueSource = character.Motion.AngularSpeed;
            float valueTarget = (float) this.m_AngularSpeed.Get(args);

            await CharacterTween.Run(
                character,
                "property:angular-speed",
                valueSource,
                valueTarget,
                value => character.Motion.AngularSpeed = value,
                this.m_Transition,
                args
            );
        }
    }
}