using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Play Footstep")]
    [Description("Plays a Footstep sound from a Material Sound asset")]

    [Category("Characters/Footsteps/Play Footstep")]

    [Parameter("Character", "The character target")]
    [Parameter("Material Sound", "The material sound asset")]

    [Keywords("Step", "Foot", "Impact", "Land", "Sound")]
    [Image(typeof(IconFootprint), ColorTheme.Type.Green)]

    [Serializable]
    public class InstructionCharacterPlayFootstep : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] 
        private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        [SerializeField] 
        private MaterialSoundsAsset m_MaterialSounds;

        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Play Footstep on {this.m_Character}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            if (this.m_MaterialSounds == null) return Done;
            
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            character.Footsteps.PlayFootstepSound(this.m_MaterialSounds);
            return Done;
        }
    }
}