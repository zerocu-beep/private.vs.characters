using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Compare Foot Phase")]
    [Description("Returns true if the chosen foot phase is currently grounded")]

    [Category("Characters/Properties/Compare Foot Phase")]

    [Keywords("Feet", "Foot", "Grounded")]
    
    

    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]
    [Serializable]
    public class ConditionCharacterPhase : TConditionCharacter
    {
        private enum PhaseLimb
        {
            LeftFoot  = 0,
            RightFoot = 1
        }
        
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private PhaseLimb m_Phase = PhaseLimb.LeftFoot;
        [SerializeField] private bool m_IsGrounded = true;
        
        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => string.Format(
            "Phase of {0} {1} {2}",
            this.m_Character,
            this.m_Phase, 
            this.m_IsGrounded ? "is Grounded" : "not Grounded"
        );
        
        // RUN METHOD: ----------------------------------------------------------------------------

        protected override bool Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return false;

            bool isGrounded = character.Phases.IsGround((int) this.m_Phase);
            return isGrounded == this.m_IsGrounded;
        }
    }
}
