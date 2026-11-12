using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Is Controllable")]
    [Description("Changes whether the Character (Player) responds using input commands")]

    [Category("Characters/Properties/Is Controllable")]

    [Parameter("Character", "The character target")]
    [Parameter("Is Controllable", "Whether the character responds to input commands")]
    
    [Image(typeof(IconPlayer), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterPropertyIsControllable : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField]
        private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        [Space] [SerializeField]
        private GetBool m_IsControllable = new GetBool(true);

        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Is Controllable {this.m_Character} = {this.m_IsControllable}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;
            
            bool valueTarget = this.m_IsControllable.Get(args);
            character.Player.IsControllable = valueTarget;
            return Done;
        }
    }
}