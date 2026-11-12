using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Stop Move")]
    [Description("Attempts to stop the character from moving")]

    [Category("Characters/Navigation/Stop Move")]
    
    [Parameter("Priority", "Indicates the priority of this command against others")]

    [Keywords("Constant", "Walk", "Run", "To", "Vector")]
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Red, typeof(BadgeCross))]

    [Serializable]
    public class InstructionCharacterNavigationMoveStop : TInstructionCharacterNavigation
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetInteger m_Priority = new GetInteger(1);

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Stop {this.m_Character} movement";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            int priority = (int) this.m_Priority.Get(args);
            character.Motion.StopToDirection(priority);
            
            return Done;
        }
    }
}