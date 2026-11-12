using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("On Dodge")]
    [Image(typeof(IconCharacterDash), ColorTheme.Type.Green)]
    
    [Category("Characters/Combat/On Dodge")]
    [Description("Executed every time the character evades an attack")]

    [Serializable]
    public class EventCharacterOnDodge : TEventCharacter
    {
        protected override void WhenEnabled(Character character)
        {
            character.Dash.EventDodge += this.OnDodge;
        }

        protected override void WhenDisabled(Character character)
        {
            character.Dash.EventDodge -= this.OnDodge;
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnDodge()
        {
            Character character = this.m_CurrentSource;
            if (character != null) this.Execute(character.gameObject);
        }
    }
}