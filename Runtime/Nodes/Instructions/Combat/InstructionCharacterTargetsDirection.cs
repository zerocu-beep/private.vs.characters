using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Cycle Direction Target")]
    [Description("Cycles to the visually closest target candidate from the Targets list and camera")]

    [Category("Characters/Combat/Targeting/Cycle Direction Target")]
    
    [Parameter("Character", "The Character that attempts to change its candidate target")]
    [Parameter("Camera", "The point of view from which the direction is calculated")]
    [Parameter("Direction", "The local space direction (only [X,Y] components are used)")]

    [Keywords("Character", "Combat", "Focus", "Pick", "Candidate", "Targets")]
    [Image(typeof(IconBullsEye), ColorTheme.Type.Yellow, typeof(BadgeBolt))]

    [Serializable]
    public class InstructionCharacterTargetsDirection : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        [SerializeField] private GetGameObject m_Camera = new GetGameObject(new TypeGameObjectCameraMain());
        [SerializeField] private GetVector3 m_Direction = new GetVector3(new TypeVector3DirectionCharacterMoving());

        protected override string GetTitle(GameObject source) => $"Cycle {this.m_Character} Direction Targets from {this.m_Camera}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            Camera camera = this.m_Camera.Get<Camera>(args);
            if (camera == null) return Done;

            Vector3 direction = this.m_Direction.Get(args);
            CycleTargets.Direction(character, camera, direction);
            
            return Done;
        }
    }
}