using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Angular Speed")]
    [Category("Characters/Navigation/Angular Speed")]
    
    [Image(typeof(IconRotationYaw), ColorTheme.Type.Yellow)]
    [Description("The Character's Angular Speed value")]

    [Keywords("Float", "Decimal", "Double", "Rotation", "Look")]
    [Get]
    [Serializable]
    public class TypeNumberCharacterAngularSpeed : TypeNumber
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        public override double Get(Args args) => this.GetValue(args);

        private float GetValue(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null ? character.Motion.AngularSpeed : 0f;
        }

        public TypeNumberCharacterAngularSpeed() : base()
        { }

        public static GetNumber Create => new GetNumber(
            new TypeNumberCharacterAngularSpeed()
        );

        public override string ToString() => $"{this.m_Character} Angular Speed";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}