using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Compare Radius")]
    [Description("Returns true if the comparison between a number and the Character's radius is satisfied")]

    [Category("Characters/Properties/Compare Radius")]

    [Keywords("Diameter", "Width", "Fat", "Skin", "Space")]
    
    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]
    [Serializable]
    public class ConditionCharacterCompareRadius : TConditionCharacter
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private CompareNumber m_Compare = new CompareNumber();
        [SerializeField] private GetNumber m_Value = new GetNumber(0.5f);
        
        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Radius of {this.m_Character} {this.m_Compare} {this.m_Value}";
        
        // RUN METHOD: ----------------------------------------------------------------------------

        protected override bool Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null && this.m_Compare.Compare(character.Motion.Radius, this.m_Value.Get(args));
        }
    }
}
