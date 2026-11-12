using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Can Jump")]
    [Description("Changes whether the Character is allowed to jump or not")]

    [Category("Characters/Properties/Can Jump")]

    [Parameter("Character", "The character target")]
    [Parameter("Can Jump", "Whether the character is allowed to jump or not")]
    
    [Keywords("Hop", "Elevate")]
    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterPropertyCanJump : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] 
        private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        
        [Space]
        [SerializeField] private GetBool m_CanJump = new GetBool(true);

        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Can Jump {this.m_Character} = {this.m_CanJump}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;
            
            bool valueTarget = this.m_CanJump.Get(args);
            character.Motion.CanJump = valueTarget;
            return Done;
        }
    }
}