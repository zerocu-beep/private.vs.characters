using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Compare Terminal Velocity")]
    [Description("Returns true if the comparison between a number and the Character's terminal velocity is satisfied")]

    [Category("Characters/Properties/Terminal Velocity")]

    [Keywords("Max", "Fall", "Vertical", "Down")]
    
    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]
    [Serializable]
    public class ConditionCharacterCompareTerminalVelocity : TConditionCharacter
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private CompareNumber m_Compare = new CompareNumber();
        [SerializeField] private GetNumber m_Value = new GetNumber(-52);
        
        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Terminal Velocity of {this.m_Character} {this.m_Compare} {this.m_Value}";
        
        // RUN METHOD: ----------------------------------------------------------------------------

        protected override bool Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return false;

            return this.m_Compare.Compare(character.Motion.TerminalVelocity, this.m_Value.Get(args));
        }
    }
}
