using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Can Collide")]
    [Description("Changes whether the Character can collide with other objects or not")]

    [Category("Characters/Properties/Can Collide")]

    [Parameter("Character", "The character target")]
    [Parameter("Can Collide", "Whether the character collides with other physic objects")]
    
    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterPropertyCollision : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField]
        private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        [Space] [SerializeField]
        private GetBool m_CanCollide = new GetBool(true);

        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Can Collide {this.m_Character} = {this.m_CanCollide}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;
            
            bool value = this.m_CanCollide.Get(args);
            character.Driver.Collision = value;
            return Done;
        }
    }
}