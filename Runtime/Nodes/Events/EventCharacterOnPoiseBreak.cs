using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("On Poise Break")]
    [Image(typeof(IconShieldOutline), ColorTheme.Type.Red, typeof(BadgeBolt))]
    
    [Category("Characters/Combat/On Poise Break")]
    [Description("Executed when a character's Poise is broken")]
    
    [Keywords("Resistance", "Combat")]

    [Serializable]
    public class EventCharacterOnPoiseBreak : TEventCharacter
    {
        protected override void WhenEnabled(Character character)
        {
            character.Combat.Poise.EventPoiseBreak -= this.OnBreak;
            character.Combat.Poise.EventPoiseBreak += this.OnBreak;
        }

        protected override void WhenDisabled(Character character)
        {
            character.Combat.Poise.EventPoiseBreak -= this.OnBreak;
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnBreak()
        {
            Character character = this.m_CurrentSource;
            if (character != null) this.Execute(character.gameObject);
        }
    }
}