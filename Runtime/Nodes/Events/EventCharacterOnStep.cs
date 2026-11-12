using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("On Step")]
    [Image(typeof(IconFootprint), ColorTheme.Type.Yellow)]
    
    [Category("Characters/Navigation/On Step")]
    [Description("Executed every time the character takes a step")]
    
    [Keywords("Footstep", "Foot", "Feet", "Ground")]

    [Serializable]
    public class EventCharacterOnStep : TEventCharacter
    {
        protected override void WhenEnabled(Character character)
        {
            character.Footsteps.EventStep += this.OnStep;
        }

        protected override void WhenDisabled(Character character)
        {
            character.Footsteps.EventStep -= this.OnStep;
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnStep(Transform foot)
        {
            this.Execute(foot.gameObject);
        }
    }
}