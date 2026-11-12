using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("On Target Change")]
    [Image(typeof(IconBullsEye), ColorTheme.Type.Yellow)]
    
    [Category("Characters/Combat/On Target Change")]
    [Description("Executed every time the character's combat Target changes")]
    
    [Keywords("Focus", "Combat", "Aim")]

    [Serializable]
    public class EventCharacterOnTarget : TEventCharacter
    {
        protected override void WhenEnabled(Character character)
        {
            character.Combat.Targets.EventChangeTarget -= this.OnChangeTarget;
            character.Combat.Targets.EventChangeTarget += this.OnChangeTarget;
        }

        protected override void WhenDisabled(Character character)
        {
            character.Combat.Targets.EventChangeTarget -= this.OnChangeTarget;
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnChangeTarget(GameObject newTarget)
        {
            this.Execute(newTarget);
        }
    }
}