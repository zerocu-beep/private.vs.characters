using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("On Defense Change")]
    [Image(typeof(IconShieldSolid), ColorTheme.Type.Blue)]
    
    [Category("Characters/Combat/On Defense Change")]
    [Description("Executed when the Character's defense changes")]
    
    [Keywords("Defend", "Block", "Combat")]

    [Serializable]
    public class EventCharacterOnDefenseChange : TEventCharacter
    {
        protected override void WhenEnabled(Character character)
        {
            character.Combat.EventDefenseChange -= this.OnChangeDefense;
            character.Combat.EventDefenseChange += this.OnChangeDefense;
        }

        protected override void WhenDisabled(Character character)
        {
            character.Combat.EventDefenseChange -= this.OnChangeDefense;
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnChangeDefense()
        {
            Character character = this.m_CurrentSource;
            if (character != null) this.Execute(character.gameObject);
        }
    }
}