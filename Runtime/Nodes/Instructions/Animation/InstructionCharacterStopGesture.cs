using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Stop Gestures")]
    [Description("Stops any animation Gestures playing on the Character")]

    [Category("Characters/Animation/Stop Gesture")]

    [Parameter("Character", "The character that plays animation Gestures")]
    [Parameter("Delay", "Amount of seconds to wait before the animation starts to blend out")]
    [Parameter("Transition", "The amount of seconds the animation takes to blend out")]

    [Keywords("Characters", "Animation", "Animate", "Gesture", "Play")]
    [Image(typeof(IconCharacterGesture), ColorTheme.Type.TextLight, typeof(BadgeCross))]
    
    [Serializable]
    public class InstructionCharacterStopGesture : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        [Space] 
        [SerializeField] private GetNumber m_Delay = new GetNumber(0f);
        [SerializeField] private GetNumber m_Transition = new GetNumber(0.1f);

        protected override string GetTitle(GameObject source) => $"Stop gestures on {this.m_Character}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            character.Gestures.Stop(
                (float) this.m_Delay.Get(args), 
                (float) this.m_Transition.Get(args)
            );
            
            return Done;
        }
    }
}