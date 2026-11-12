using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("On Revive")]
    [Image(typeof(IconSkull), ColorTheme.Type.Green)]
    
    [Category("Characters/On Revive")]
    [Description("Executed when a dead character revives")]
    
    [Keywords("Resurrect", "Respawn")]
    
    [Serializable]
    public class EventCharacterOnRevive : TEventCharacter
    {
        protected override void WhenEnabled(Character character)
        {
            character.EventRevive += this.OnRevive;
        }

        protected override void WhenDisabled(Character character)
        {
            character.EventRevive -= this.OnRevive;
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnRevive()
        {
            Character character = this.m_CurrentSource;
            if (character != null) this.Execute(character.gameObject);
        }
    }
}