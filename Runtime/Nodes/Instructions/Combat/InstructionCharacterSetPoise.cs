using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Set Poise")]
    [Description("Changes the current Poise value of a Character")]

    [Category("Characters/Combat/Poise/Set Poise")]
    
    [Parameter("Character", "The Character that attempts to change its Poise value")]
    [Parameter("Poise", "The new Poise value")]

    [Keywords("Character", "Combat")]
    [Image(typeof(IconShieldOutline), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterSetPoise : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        [SerializeField] private GetNumber m_Poise = new GetNumber(1f);

        protected override string GetTitle(GameObject source) => $"Set {this.m_Character} Poise = {this.m_Poise}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            float poise = (float) this.m_Poise.Get(args);
            character.Combat.Poise.Set(poise);

            return Done;
        }
    }
}