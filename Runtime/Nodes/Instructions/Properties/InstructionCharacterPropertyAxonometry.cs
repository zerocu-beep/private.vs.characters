using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Change Axonometry")]
    [Description("Changes the Character's Axonometry value")]

    [Category("Characters/Properties/Axonometry")]
    [Parameter("Axonometry", "The new Axonometry value")]

    [Keywords("Isometric", "Side", "Scroll")]
    [Image(typeof(IconIsometric), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterPropertyAxonometry : TInstructionCharacterProperty
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private Axonometry m_Axonometry = new Axonometry();
        
        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Axonometry of {this.m_Character} = {this.m_Axonometry}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            character.Driver.Axonometry = this.m_Axonometry.Clone() as Axonometry;
            character.Facing.Axonometry = this.m_Axonometry.Clone() as Axonometry;

            return Done;
        }
    }
}