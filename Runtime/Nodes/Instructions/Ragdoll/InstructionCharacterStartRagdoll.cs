using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Start Ragdoll")]
    [Description("Makes a Character enter a ragdoll state")]

    [Category("Characters/Ragdoll/Start Ragdoll")]

    [Parameter("Character", "The Character game object that changes to a Ragdoll state")]

    [Keywords("Characters", "Ragdoll", "Dead", "Kill", "Die")]
    [Image(typeof(IconSkeleton), ColorTheme.Type.Blue)]

    [Serializable]
    public class InstructionCharacterStartRagdoll : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        protected override string GetTitle(GameObject source) => $"Start Ragdoll on {this.m_Character}";

        protected override async Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return;

            await character.Ragdoll.StartRagdoll();
        }
    }
}