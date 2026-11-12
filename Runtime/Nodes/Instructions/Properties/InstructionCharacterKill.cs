using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Kill Character")]
    [Description("Changes the state of the Character to dead")]

    [Category("Characters/Properties/Kill Character")]

    [Parameter("Character", "The character target")]

    [Keywords("Dead", "Die", "Murder")]
    [Image(typeof(IconSkull), ColorTheme.Type.Red)]

    [Serializable]
    public class InstructionCharacterKill : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] 
        private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Kill {this.m_Character}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            character.IsDead = true;
            return Done;
        }
    }
}