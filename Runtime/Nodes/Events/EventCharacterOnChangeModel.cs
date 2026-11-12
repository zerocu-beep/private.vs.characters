using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("On Change Model")]
    [Image(typeof(IconCharacter), ColorTheme.Type.Blue)]
    
    [Category("Characters/On Change Model")]
    [Description("Executed when a character changes its model")]

    [Serializable]
    public class EventCharacterOnChangeModel : TEventCharacter
    {
        protected override void WhenEnabled(Character character)
        {
            character.EventAfterChangeModel += this.OnChangeModel;
        }

        protected override void WhenDisabled(Character character)
        {
            character.EventAfterChangeModel -= this.OnChangeModel;
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnChangeModel()
        {
            Character character = this.m_CurrentSource;
            if (character != null) this.Execute(character.gameObject);
        }
    }
}