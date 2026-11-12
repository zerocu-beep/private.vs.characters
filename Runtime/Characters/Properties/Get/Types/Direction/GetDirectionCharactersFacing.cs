using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Facing Direction")]
    [Category("Characters/Facing Direction")]
    
    [Image(typeof(IconBust), ColorTheme.Type.Yellow, typeof(BadgeArrowRight))]
    [Description("The Character's forward facing direction in world space")]

    [Get]

    [Serializable]
    public class TypeVector3DirectionCharacterFacing : TypeVector3
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        
        public override Vector3 Get(Args args) => this.GetDirection(args);

        private Vector3 GetDirection(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null ? character.transform.forward : default;
        }

        public static GetVector3 Create => new GetVector3(
            new TypeVector3DirectionCharacterFacing()
        );

        public override string ToString() => $"{this.m_Character} Direction";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}