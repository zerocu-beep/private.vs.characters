using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Recover from Ragdoll")]
    [Description("Recovers a Character from the Ragdoll state and stands up")]

    [Category("Characters/Ragdoll/Recover Ragdoll")]

    [Parameter("Character", "The Character game object that recovers from the Ragdoll state")]

    [Keywords("Characters", "Ragdoll", "Recover", "Stand")]
    [Image(typeof(IconSkeleton), ColorTheme.Type.Green)]

    [Serializable]
    public class InstructionCharacterRecoverRagdoll : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        protected override string GetTitle(GameObject source) => $"Recover Ragdoll on {this.m_Character}";

        protected override async Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return;

            await character.Ragdoll.StartRecover();
        }
    }
}