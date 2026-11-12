using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Can Jump")]
    [Category("Characters/Can Jump")]
    
    [Image(typeof(IconCharacterJump), ColorTheme.Type.Yellow)]
    [Description("Returns true if the Character can perform a jump")]
    
    [Keywords("Character", "Hop")]
    [Get]
    [Serializable]
    public class TypeBoolCharacterCanJump : TypeBool
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        public override bool Get(Args args) => this.m_Character.Get<Character>(args)?.Jump.CanJump() ?? false;

        public TypeBoolCharacterCanJump() : base()
        { }

        public static GetBool Create  => new GetBool(
            new TypeBoolCharacterCanJump()
        );

        public override string ToString() => $"{this.m_Character} Can Jump";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}