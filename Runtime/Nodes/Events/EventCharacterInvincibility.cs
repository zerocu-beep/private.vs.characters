using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("On Invincibility Change")]
    [Image(typeof(IconDiamondSolid), ColorTheme.Type.Yellow)]
    
    [Category("Characters/Combat/On Invincibility Change")]
    [Description("Executed when the character's Invincibility changes")]
    
    [Serializable]
    public class EventCharacterInvincibility : TEventCharacter
    {
        private enum Mode
        {
            OnChange,
            OnBecomeInvincible,
            OnBecomeVincible
        }
        
        // EXPOSED MEMBERS: -----------------------------------------------------------------------

        [SerializeField] private Mode m_Mode = Mode.OnChange;
        
        // PROTECTED METHODS: ---------------------------------------------------------------------
        
        protected override void WhenEnabled(Character character)
        {
            character.Combat.Invincibility.EventChange += this.OnInvincibility;
        }

        protected override void WhenDisabled(Character character)
        {
            character.Combat.Invincibility.EventChange -= this.OnInvincibility;
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnInvincibility(bool isInvincible)
        {
            Character character = this.m_CurrentSource;
            if (character == null) return;

            switch (this.m_Mode)
            {
                case Mode.OnChange:
                    this.Execute(character.gameObject);
                    break;
                
                case Mode.OnBecomeInvincible:
                    if (isInvincible) this.Execute(character.gameObject);
                    break;
                
                case Mode.OnBecomeVincible:
                    if (!isInvincible) this.Execute(character.gameObject);
                    break;
                
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}