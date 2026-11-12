using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Change State Weight")]
    [Description("Changes the weight of the State over time at the specified layer")]

    [Category("Characters/Animation/Change State Weight")]

    [Parameter("Character", "The character that plays the animation state")]
    [Parameter("Layer", "Slot number in which the animation state is allocated")]
    [Parameter("Weight", "The targeted opacity of the animation")]
    [Parameter("Transition", "The duration of the transition, in seconds")]

    [Keywords("Characters", "Animation", "Blend", "State", "Opacity")]
    [Image(typeof(IconCharacterState), ColorTheme.Type.Yellow)]
    
    [Serializable]
    public class InstructionCharacterStateWeight : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        [Space]
        [SerializeField] private GetInteger m_Layer = new GetInteger(1);
        [SerializeField] private GetNumber m_Weight = new GetNumber(1f);
        [SerializeField] private GetNumber m_Transition = new GetNumber(1f);

        protected override string GetTitle(GameObject source) => $"Change {this.m_Character} State weight to {this.m_Weight}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            int layer = (int) this.m_Layer.Get(args);
            float weight = (float) this.m_Weight.Get(args);
            float transition = (float) this.m_Transition.Get(args);
            
            character.States.ChangeWeight(layer, weight, transition);
            return Done;
        }
    }
}