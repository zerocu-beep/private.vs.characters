using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("On Dash")]
    [Image(typeof(IconCharacterDash), ColorTheme.Type.Yellow)]
    
    [Category("Characters/Navigation/On Dash")]
    [Description("Executed every time the character performs a dash")]

    [Serializable]
    public class EventCharacterOnDash : TEventCharacter
    {
        protected override void WhenEnabled(Character character)
        {
            character.Dash.EventDashStart += this.OnDash;
        }

        protected override void WhenDisabled(Character character)
        {
            character.Dash.EventDashStart -= this.OnDash;
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnDash()
        {
            Character character = this.m_CurrentSource;
            if (character != null) this.Execute(character.gameObject);
        }
    }
}