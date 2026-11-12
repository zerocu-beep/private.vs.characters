using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Change Footstep Sounds")]
    [Description("Changes the sound table that links textures with footstep sounds")]

    [Category("Characters/Footsteps/Change Footstep Sounds")]

    [Parameter("Character", "The character that plays animation Gestures")]
    [Parameter(
        "Footsteps", 
        "The sound table asset that contains information about how and when footstep sounds play"
    )]

    [Keywords("Character", "Foot", "Step", "Stomp", "Foliage", "Audio", "Run", "Walk", "Move")]
    [Image(typeof(IconFootprint), ColorTheme.Type.Yellow)]
    
    [Serializable]
    public class InstructionCharacterChangeFootsteps : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        [SerializeField] private MaterialSoundsAsset m_Materials;

        protected override string GetTitle(GameObject source) => string.Format(
            "Changes Footstep Sounds on {0} to {1}",
            this.m_Character, 
            this.m_Materials != null ? this.m_Materials.name : "(none)"
        );

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            character.Footsteps.ChangeFootstepSounds(this.m_Materials);
            return Done;
        }
    }
}