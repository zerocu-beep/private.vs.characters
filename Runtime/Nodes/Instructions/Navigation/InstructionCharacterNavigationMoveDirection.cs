using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Move Direction")]
    [Description("Attempts to move the Character towards the specified direction")]

    [Category("Characters/Navigation/Move Direction")]
    
    [Parameter("Direction", "The the direction to move towards")]
    [Parameter("Priority", "Indicates the priority of this command against others")]

    [Keywords("Constant", "Walk", "Run", "To", "Vector")]
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Blue, typeof(BadgeArrowRight))]

    [Serializable]
    public class InstructionCharacterNavigationMoveDirection : TInstructionCharacterNavigation
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetVector3 m_Direction = new GetVector3();
        [SerializeField] private GetInteger m_Priority = new GetInteger(0);

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Move {this.m_Character} to {this.m_Direction}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            Vector3 direction = this.m_Direction.Get(args);
            int priority = (int) this.m_Priority.Get(args);
            
            character.Motion.MoveToDirection(direction, Space.World, priority);
            return Done;
        }
    }
}