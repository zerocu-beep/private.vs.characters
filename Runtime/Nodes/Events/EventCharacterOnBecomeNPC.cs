using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("On Become NPC")]
    [Image(typeof(IconCharacter), ColorTheme.Type.Yellow)]
    
    [Category("Characters/On Become NPC")]
    [Description("Executed when a character that is a Player becomes an NPC")]

    [Serializable]
    public class EventCharacterOnBecomeNPC : TEventCharacter
    {
        protected override void WhenEnabled(Character character)
        {
            character.EventChangeToNPC += this.OnChangeToNPC;
        }

        protected override void WhenDisabled(Character character)
        {
            character.EventChangeToNPC -= this.OnChangeToNPC;
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnChangeToNPC()
        {
            Character character = this.m_CurrentSource;
            if (character != null) this.Execute(character.gameObject);
        }
    }
}