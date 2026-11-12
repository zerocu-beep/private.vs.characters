using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Set Invincible")]
    [Description("Changes the Invincibility state of a Character")]

    [Category("Characters/Combat/Invincibility/Set Invincible")]
    
    [Parameter("Character", "The Character that attempts to change its invincibility")]
    [Parameter("Duration", "The duration of the invincibility")]
    [Parameter("Wait Until Complete", "Whether to wait until the invincibility wears off")]

    [Keywords("Character", "Combat", "Invincibility")]
    [Image(typeof(IconDiamondSolid), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterSetInvincible : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        [SerializeField] private GetNumber m_Duration = new GetNumber(1f);
        [SerializeField] private bool m_WaitUntilComplete;

        protected override string GetTitle(GameObject source) => $"Set {this.m_Character} Invincible for {this.m_Duration} seconds";

        protected override async Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return;

            float duration = (float) this.m_Duration.Get(args);
            character.Combat.Invincibility.Set(duration);

            if (this.m_WaitUntilComplete) await this.WaitForSeconds(duration);
        }
    }
}