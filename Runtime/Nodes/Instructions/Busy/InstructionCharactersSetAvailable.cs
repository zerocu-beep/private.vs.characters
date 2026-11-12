using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Set Available")]
    [Description("Sets the Available state of a Character's Limbs")]

    [Category("Characters/Busy/Set Available")]

    [Parameter("Character", "The Character game object")]
    [Parameter("Limbs", "The Limbs that are changed to Available")]

    [Keywords("Characters", "Busy", "Occupied", "Using")]
    [Image(typeof(IconCharacter), ColorTheme.Type.Green)]

    [Serializable]
    public class InstructionCharactersSetAvailable : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        [SerializeField] private Busy.Limb m_Limbs = Busy.Limb.Every;

        protected override string GetTitle(GameObject source) => $"Set {this.m_Character} Available = {this.m_Limbs}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character != null) character.Busy.RemoveState(this.m_Limbs);
            return Done;
        }
    }
}