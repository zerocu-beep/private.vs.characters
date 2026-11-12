using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("On Land")]
    [Image(typeof(IconLand), ColorTheme.Type.Yellow)]
    
    [Category("Characters/Navigation/On Land")]
    [Description("Executed every time the character lands on the ground")]

    [Serializable]
    public class EventCharacterOnLand : TEventCharacter
    {
        protected override void WhenEnabled(Character character)
        {
            character.EventLand += this.OnStep;
        }

        protected override void WhenDisabled(Character character)
        {
            character.EventLand -= this.OnStep;
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnStep(float velocity)
        {
            Character character = this.m_CurrentSource;
            if (character != null) this.Execute(character.gameObject);
        }
    }
}