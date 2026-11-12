using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Set Dashes")]
    [Description("Sets the number of consecutive dashes of a Character")]

    [Category("Characters/Navigation/Set Dashes")]
    
    [Keywords("Flash", "Roll", "Reach")]
    [Image(typeof(IconCharacterDash), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterSetDashes : TInstructionCharacterNavigation
    {
        [SerializeField] private GetInteger m_Dashes = new GetInteger(2);
        
        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Dashes of {this.m_Character} = {this.m_Dashes}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;
            
            character.Dash.NumDashes = Mathf.Max((int) this.m_Dashes.Get(args), 0);
            return Done;
        }
    }
}