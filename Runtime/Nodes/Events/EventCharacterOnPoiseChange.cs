using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("On Poise Change")]
    [Image(typeof(IconShieldOutline), ColorTheme.Type.Yellow)]
    
    [Category("Characters/Combat/On Poise Change")]
    [Description("Executed every time the character's combat Poise changes")]
    
    [Keywords("Resistance", "Combat")]

    [Serializable]
    public class EventCharacterOnPoiseChange : TEventCharacter
    {
        protected override void WhenEnabled(Character character)
        {
            character.Combat.Poise.EventChange -= this.OnChange;
            character.Combat.Poise.EventChange += this.OnChange;
        }

        protected override void WhenDisabled(Character character)
        {
            character.Combat.Poise.EventChange -= this.OnChange;
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnChange()
        {
            Character character = this.m_CurrentSource;
            if (character != null) this.Execute(character.gameObject);
        }
    }
}