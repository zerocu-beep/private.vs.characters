using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Linear Speed")]
    [Category("Characters/Navigation/Linear Speed")]
    
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Yellow)]
    [Description("The Character's Linear Speed value")]

    [Keywords("Float", "Decimal", "Double")]
    [Get]
    [Serializable]
    public class TypeNumberCharacterLinearSpeed : TypeNumber
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        public override double Get(Args args) => this.GetValue(args);

        private float GetValue(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null ? character.Motion.LinearSpeed : 0f;
        }

        public TypeNumberCharacterLinearSpeed() : base()
        { }

        public static GetNumber Create => new GetNumber(
            new TypeNumberCharacterLinearSpeed()
        );

        public override string ToString() => $"{this.m_Character} Linear Speed";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}