using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    /// <summary>
    /// Makes its game object an interactive one and runs when the Character stops focusing it.
    /// </summary>
    [Title("On Blur")]
    [Category("Interactive/On Blur")]
    [Description("Executed when the Character stops focusing on this interactive object")]

    [Image(typeof(IconCharacterInteract), ColorTheme.Type.Red, typeof(BadgeDot))]
    [Keywords("Interaction", "Deselect", "Unhighlight", "Exit")]

    [Serializable]
    public class EventCharacterOnBlurInteractive : TEventCharacter
    {
        protected override void WhenEnabled(Character character)
        {
            if (this.Component != null) InteractionTracker.Require(this.Component.gameObject);
            character.Interaction.EventBlur += this.OnBlur;
        }

        protected override void WhenDisabled(Character character)
        {
            character.Interaction.EventBlur -= this.OnBlur;
        }

        private void OnBlur(Character character, IInteractive interactive)
        {
            if (character == null || interactive == null) return;
            if (this.Component == null || interactive.Instance != this.Component.gameObject) return;

            this.Execute(character.gameObject);
        }
    }
}
