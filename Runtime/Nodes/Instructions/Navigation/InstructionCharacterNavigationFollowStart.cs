using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Start Following")]
    [Description("Instructs a Character to follow another game object")]

    [Category("Characters/Navigation/Start Following")]

    [Parameter("Target", "The target game object to follow")]
    
    [Parameter(
        "Min Distance", 
        "Distance from the Target the Character aims to move when approaching the Target"
    )]
    
    [Parameter(
        "Max Distance", 
        "Maximum distance to the Target the Character leaves before attempting to move closer"
    )]
    
    [Keywords("Lead", "Pursue", "Chase", "Walk", "Run", "Position", "Location", "Destination")]
    [Image(typeof(IconCharacterRun), ColorTheme.Type.Blue)]

    [Serializable]
    public class InstructionCharacterNavigationFollowStart : TInstructionCharacterNavigation
    {
        // EXPOSED MEMBERS: -----------------------------------------------------------------------

        [SerializeField] private GetGameObject m_FollowTarget = new GetGameObject(new TypeGameObjectPlayer());

        [SerializeField] private GetNumber m_MinDistance = new GetNumber(2f);
        [SerializeField] private GetNumber m_MaxDistance = new GetNumber(4f);

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"{this.m_Character} Follow {this.m_FollowTarget}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            GameObject target = this.m_FollowTarget.Get(args);
            if (target == null) return Done;
            
            character.Motion.StartFollowingTarget(
                target.transform,
                (float) this.m_MinDistance.Get(args),
                (float) this.m_MaxDistance.Get(args)
            );

            return Done;
        }
    }
}