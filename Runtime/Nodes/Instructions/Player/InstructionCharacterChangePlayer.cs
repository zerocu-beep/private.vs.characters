using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Change Player")]
    [Description("Changes the Character identified as the Player")]

    [Category("Characters/Player/Change Player")]
    
    [Parameter("Character", "The Character becomes the new Player character")]

    [Keywords("Character", "Is", "Control")]
    [Image(typeof(IconPlayer), ColorTheme.Type.Green)]

    [Serializable]
    public class InstructionCharacterChangePlayer : Instruction
    {
        [SerializeField] private GetGameObject m_NewPlayer = new GetGameObject(new TypeGameObjectPlayer());

        protected override string GetTitle(GameObject source) => $"Change Player to {this.m_NewPlayer}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_NewPlayer.Get<Character>(args);
            if (character == null) return Done;

            Character previous = ShortcutPlayer.Get<Character>();
            if (previous != null) previous.IsPlayer = false;
            
            character.IsPlayer = true;
            return Done;
        }
    }
}