using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Set Fulcrum")]
    [Description("Changes the Fulcrum value of a Character")]

    [Category("Characters/Footsteps/Set Character Fulcrum")]

    [Parameter("Character", "The character targeted")]
    [Parameter("Fulcrum", "The new Fulcrum value")]

    [Keywords("Character", "Foot", "Step", "Stomp", "Foliage", "Audio", "Run", "Walk", "Move")]
    [Image(typeof(IconFootprint), ColorTheme.Type.Yellow)]
    
    [Serializable]
    public class InstructionCharacterSetFulcrum : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        [SerializeField] private GetNumber m_Fulcrum = new GetNumber(-0.85f);

        protected override string GetTitle(GameObject source) => $"Fulcrum of {this.m_Character} = {this.m_Fulcrum}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;
            
            if (character.Footsteps.FootstepDetector is FootstepDetectorFulcrum fulcrumDetector)
            {
                fulcrumDetector.Fulcrum = (float) this.m_Fulcrum.Get(args);
            }
            
            return Done;
        }
    }
}