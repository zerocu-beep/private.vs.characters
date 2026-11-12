using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Moving Direction")]
    [Category("Characters/Moving Direction")]
    
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Yellow, typeof(BadgeArrowRight))]
    [Description("The Character's moving direction in world space")]

    [Get]

    [Serializable]
    public class TypeVector3DirectionCharacterMoving : TypeVector3
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        
        public override Vector3 Get(Args args) => this.GetDirection(args);

        private Vector3 GetDirection(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null ? character.Driver.WorldMoveDirection : default;
        }
        
        public static GetVector3 Create => new GetVector3(
            new TypeVector3DirectionCharacterMoving()
        );

        public override string ToString() => $"{this.m_Character} Move";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}