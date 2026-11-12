using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Footsteps Set Active")]
    [Description("Changes whether a Character plays footstep events or not")]

    [Category("Characters/Footsteps/Footsteps Set Active")]

    [Parameter("Character", "The character targeted")]
    [Parameter("Active", "Whether the footstep events are executed or not")]

    [Keywords("Character", "Foot", "Step", "Stomp", "Foliage", "Audio", "Run", "Walk", "Move")]
    [Image(typeof(IconFootprint), ColorTheme.Type.Yellow)]
    
    [Serializable]
    public class InstructionCharacterFootstepsActive : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        [SerializeField] private GetBool m_Active = new GetBool(true);

        protected override string GetTitle(GameObject source) => $"Footstep of {this.m_Character} = {this.m_Active}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;
            
            character.Footsteps.IsActive = this.m_Active.Get(args);
            return Done;
        }
    }
}