using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Compare Mass")]
    [Description("Returns true if the comparison between a number and the Character's mass is satisfied")]

    [Category("Characters/Properties/Compare Mass")]

    [Keywords("Weight")]
    
    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]
    [Serializable]
    public class ConditionCharacterCompareMass : TConditionCharacter
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private CompareNumber m_Compare = new CompareNumber();
        [SerializeField] private GetNumber m_Value = new GetNumber(75f);
        
        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Mass of {this.m_Character} {this.m_Compare} {this.m_Value}";
        
        // RUN METHOD: ----------------------------------------------------------------------------

        protected override bool Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null && this.m_Compare.Compare(character.Motion.Mass, this.m_Value.Get(args));
        }
    }
}
