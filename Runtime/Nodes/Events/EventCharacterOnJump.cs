using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("On Jump")]
    [Image(typeof(IconCharacterJump), ColorTheme.Type.Yellow)]
    
    [Category("Characters/Navigation/On Jump")]
    [Description("Executed every time the character performs a jump")]

    [Serializable]
    public class EventCharacterOnJump : TEventCharacter
    {
        protected override void WhenEnabled(Character character)
        {
            character.EventJump += this.OnJump;
        }

        protected override void WhenDisabled(Character character)
        {
            character.EventJump -= this.OnJump;
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnJump(float velocity)
        {
            Character character = this.m_CurrentSource;
            if (character != null) this.Execute(character.gameObject);
        }
    }
}