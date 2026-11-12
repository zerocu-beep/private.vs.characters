using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Set Busy")]
    [Description("Sets the Busy state of a Character's Limbs")]

    [Category("Characters/Busy/Set Busy")]

    [Parameter("Character", "The Character game object")]
    [Parameter("Limbs", "The Limbs that are changed to Busy")]

    [Keywords("Characters", "Busy", "Occupied", "Using")]
    [Image(typeof(IconCharacter), ColorTheme.Type.Red)]

    [Serializable]
    public class InstructionCharactersSetBusy : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        [SerializeField] private Busy.Limb m_Limbs = Busy.Limb.Every;

        protected override string GetTitle(GameObject source) => $"Set {this.m_Character} Busy = {this.m_Limbs}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character != null) character.Busy.AddState(this.m_Limbs);
            return Done;
        }
    }
}