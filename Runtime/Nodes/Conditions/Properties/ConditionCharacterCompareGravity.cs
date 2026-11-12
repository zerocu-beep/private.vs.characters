using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Compare Gravity")]
    [Description("Returns true if the comparison between a number and the Character's gravity is satisfied")]

    [Category("Characters/Properties/Compare Gravity")]

    [Keywords("Force", "Vertical")]
    
    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]
    [Serializable]
    public class ConditionCharacterCompareGravity : TConditionCharacter
    {
        private enum Mode
        {
            Average,
            GravityUpwards,
            GravityDownwards
        }
        
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private Mode m_Mode = Mode.Average;
        [SerializeField] private CompareNumber m_Compare = new CompareNumber();
        [SerializeField] private GetNumber m_Value = new GetNumber(2f);
        
        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => string.Format(
            "{0}Gravity of {1} {2}",
            this.m_Mode switch
            {
                Mode.Average => string.Empty,
                Mode.GravityUpwards => "Upwards ",
                Mode.GravityDownwards => "Downwards ",
                _ => throw new ArgumentOutOfRangeException()
            },
            this.m_Character, 
            this.m_Compare + " " + this.m_Value
        );
        
        // RUN METHOD: ----------------------------------------------------------------------------

        protected override bool Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            float gravity = this.m_Mode switch
            {
                Mode.Average => (character.Motion.GravityUpwards + character.Motion.GravityDownwards) / 2f,
                Mode.GravityUpwards => character.Motion.GravityUpwards,
                Mode.GravityDownwards => character.Motion.GravityDownwards,
                _ => throw new ArgumentOutOfRangeException()
            };
            
            return character != null && this.m_Compare.Compare(gravity, this.m_Value.Get(args));
        }
    }
}
