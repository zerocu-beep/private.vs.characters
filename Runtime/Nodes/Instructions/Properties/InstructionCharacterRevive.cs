using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Revive Character")]
    [Description("Changes the state of the Character to alive")]

    [Category("Characters/Properties/Revive Character")]

    [Parameter("Character", "The character target")]

    [Keywords("Respawn", "Alive", "Resurrect")]
    [Image(typeof(IconSkull), ColorTheme.Type.Green)]

    [Serializable]
    public class InstructionCharacterRevive : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField]
        private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Revive {this.m_Character}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            character.IsDead = false;
            return Done;
        }
    }
}