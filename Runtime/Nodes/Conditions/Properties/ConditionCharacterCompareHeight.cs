using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Compare Height")]
    [Description("Returns true if the comparison between a number and the Character's height is satisfied")]

    [Category("Characters/Properties/Compare Height")]

    [Keywords("Length", "Long")]
    
    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]
    [Serializable]
    public class ConditionCharacterCompareHeight : TConditionCharacter
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private CompareNumber m_Compare = new CompareNumber();
        [SerializeField] private GetNumber m_Value = new GetNumber(-9.81f);
        
        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Height of {this.m_Character} {this.m_Compare} {this.m_Value}";
        
        // RUN METHOD: ----------------------------------------------------------------------------

        protected override bool Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null && this.m_Compare.Compare(character.Motion.Height, this.m_Value.Get(args));
        }
    }
}
