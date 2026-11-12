using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Change Time Mode")]
    [Description("Changes the Character's Time Mode")]

    [Category("Characters/Properties/Change Time Mode")]
    
    [Parameter("Time Mode", "The target Time Mode for the Character")]

    [Keywords("Scale", "Game")]
    [Image(typeof(IconTimer), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterPropertyTimeMode : TInstructionCharacterProperty
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private CharacterTime.UpdateMode m_TimeMode = CharacterTime.UpdateMode.GameTime;

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Time Mode {this.m_Character} = {this.m_TimeMode}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            character.Time = new CharacterTime(this.m_TimeMode);
            return Done;
        }
    }
}