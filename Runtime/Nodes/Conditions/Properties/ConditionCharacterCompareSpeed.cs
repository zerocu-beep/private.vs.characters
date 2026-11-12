using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Compare Speed")]
    [Description("Returns true if the comparison between a number and the Character's speed is satisfied")]

    [Category("Characters/Properties/Compare Speed")]

    [Keywords("Velocity", "Travel", "Movement", "Walk", "Run", "Step")]
    
    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]
    [Serializable]
    public class ConditionCharacterCompareSpeed : TConditionCharacter
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private CompareNumber m_Compare = new CompareNumber();
        [SerializeField] private GetNumber m_Value = new GetNumber(4f);
        
        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Speed of {this.m_Character} {this.m_Compare} {this.m_Value}";
        
        // RUN METHOD: ----------------------------------------------------------------------------

        protected override bool Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null && this.m_Compare.Compare(character.Motion.LinearSpeed, this.m_Value.Get(args));
        }
    }
}
