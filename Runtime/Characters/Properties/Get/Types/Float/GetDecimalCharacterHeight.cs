using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Character Height")]
    [Category("Characters/Properties/Character Height")]
    
    [Image(typeof(IconCharacter), ColorTheme.Type.Yellow)]
    [Description("The Character's Height value")]

    [Keywords("Float", "Decimal", "Double", "Up", "Size")]
    [Get]
    [Serializable]
    public class TypeNumberCharacterHeight : TypeNumber
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        public override double Get(Args args) => this.GetValue(args);

        private float GetValue(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null ? character.Motion.Height : 0f;
        }

        public TypeNumberCharacterHeight() : base()
        { }

        public static GetNumber Create => new GetNumber(
            new TypeNumberCharacterHeight()
        );

        public override string ToString() => $"{this.m_Character} Height";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}