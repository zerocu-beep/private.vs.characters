using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Stop State")]
    [Description("Stops an animation State from a Character")]

    [Category("Characters/Animation/Stop State")]

    [Parameter("Character", "The character that stops its animation State")]
    [Parameter("Layer", "Slot number from which the state is removed")]

    [Parameter("Delay", "Amount of seconds to wait before the animation stops playing")]
    [Parameter("Transition", "The amount of seconds the animation takes to blend out")]

    [Keywords("Characters", "Animation", "Animate", "State", "Exit", "Stop")]
    [Image(typeof(IconCharacterState), ColorTheme.Type.TextLight, typeof(BadgeCross))]
    
    [Serializable]
    public class InstructionCharacterStopState : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        [Space]
        [SerializeField] private GetInteger m_Layer = new GetInteger(1);

        [Space] 
        [SerializeField] private GetNumber m_Delay = new GetNumber(0f);
        [SerializeField] private GetNumber m_Transition = new GetNumber(0.1f);

        protected override string GetTitle(GameObject source) => $"Stop {this.m_Character} State in Layer {this.m_Layer}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            int layer = (int) this.m_Layer.Get(args);
            character.States.Stop(
                layer,
                (float) this.m_Delay.Get(args),
                (float) this.m_Transition.Get(args)
            );
            
            return Done;
        }
    }
}