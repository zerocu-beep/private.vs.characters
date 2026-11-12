using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("On Die")]
    [Image(typeof(IconSkull), ColorTheme.Type.Red)]
    
    [Category("Characters/On Die")]
    [Description("Executed when the character dies")]
    
    [Serializable]
    public class EventCharacterOnDie : TEventCharacter
    {
        protected override void WhenEnabled(Character character)
        {
            character.EventDie += this.OnDie;
        }

        protected override void WhenDisabled(Character character)
        {
            character.EventDie -= this.OnDie;
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnDie()
        {
            Character character = this.m_CurrentSource;
            if (character != null) this.Execute(character.gameObject);
        }
    }
}