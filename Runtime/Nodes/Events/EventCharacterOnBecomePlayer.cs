using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("On Become Player")]
    [Image(typeof(IconPlayer), ColorTheme.Type.Yellow)]
    
    [Category("Characters/On Become Player")]
    [Description("Executed when a character becomes the Player")]

    [Serializable]
    public class EventCharacterOnBecomePlayer : TEventCharacter
    {
        protected override void WhenEnabled(Character character)
        {
            character.EventChangeToPlayer += this.OnChangeToPlayer;
        }

        protected override void WhenDisabled(Character character)
        {
            character.EventChangeToPlayer -= this.OnChangeToPlayer;
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnChangeToPlayer()
        {
            Character character = this.m_CurrentSource;
            if (character != null) this.Execute(character.gameObject);
        }
    }
}