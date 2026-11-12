using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Jump Force")]
    [Category("Characters/Navigation/Jump Force")]
    
    [Image(typeof(IconCharacterJump), ColorTheme.Type.Yellow)]
    [Description("The Character's Jump Force value")]

    [Keywords("Float", "Decimal", "Double", "Hop", "Elevate", "Impulse")]
    [Get]
    [Serializable]
    public class TypeNumberCharacterJumpForce : TypeNumber
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        public override double Get(Args args) => this.GetValue(args);

        private float GetValue(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null ? character.Motion.JumpForce : 0f;
        }

        public TypeNumberCharacterJumpForce() : base()
        { }

        public static GetNumber Create => new GetNumber(
            new TypeNumberCharacterJumpForce()
        );

        public override string ToString() => $"{this.m_Character} Jump Force";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}