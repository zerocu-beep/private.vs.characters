using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    /// <summary>
    /// Makes its game object an interactive one and runs when the Character starts focusing
    /// it (it becomes the object the Character would interact with).
    /// </summary>
    [Title("On Focus")]
    [Category("Interactive/On Focus")]
    [Description("Executed when the Character focuses on this interactive object")]

    [Image(typeof(IconCharacterInteract), ColorTheme.Type.Green, typeof(BadgeDot))]
    [Keywords("Interaction", "Select", "Highlight", "Hover")]

    [Serializable]
    public class EventCharacterOnFocusInteractive : TEventCharacter
    {
        protected override void WhenEnabled(Character character)
        {
            if (this.Component != null) InteractionTracker.Require(this.Component.gameObject);
            character.Interaction.EventFocus += this.OnFocus;
        }

        protected override void WhenDisabled(Character character)
        {
            character.Interaction.EventFocus -= this.OnFocus;
        }

        private void OnFocus(Character character, IInteractive interactive)
        {
            if (character == null || interactive == null) return;
            if (this.Component == null || interactive.Instance != this.Component.gameObject) return;

            this.Execute(character.gameObject);
        }
    }
}
