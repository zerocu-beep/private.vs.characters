using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Character Radius")]
    [Category("Characters/Properties/Character Radius")]
    
    [Image(typeof(IconCharacter), ColorTheme.Type.Yellow)]
    [Description("The Character's Radius value")]

    [Keywords("Float", "Decimal", "Double", "Width", "Diameter")]
    [Get]
    [Serializable]
    public class TypeNumberCharacterRadius : TypeNumber
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        public override double Get(Args args) => this.GetValue(args);

        private float GetValue(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null ? character.Motion.Radius : 0f;
        }

        public TypeNumberCharacterRadius() : base()
        { }

        public static GetNumber Create => new GetNumber(
            new TypeNumberCharacterRadius()
        );

        public override string ToString() => $"{this.m_Character} Radius";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}