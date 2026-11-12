using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Current Velocity")]
    [Category("Characters/Navigation/Current Velocity")]
    
    [Image(typeof(IconCharacterRun), ColorTheme.Type.Blue, typeof(BadgeArrowRight))]
    [Description("The current velocity at which the Character is moving")]

    [Keywords("Float", "Decimal", "Double")]
    [Get]
    [Serializable]
    public class TypeNumberCharacterCurrentVelocity : TypeNumber
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        public override double Get(Args args) => this.GetValue(args);

        private float GetValue(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null ? character.Driver.WorldMoveDirection.magnitude : 0f;
        }

        public TypeNumberCharacterCurrentVelocity() : base()
        { }

        public static GetNumber Create => new GetNumber(
            new TypeNumberCharacterCurrentVelocity()
        );

        public override string ToString() => $"{this.m_Character} Velocity";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}