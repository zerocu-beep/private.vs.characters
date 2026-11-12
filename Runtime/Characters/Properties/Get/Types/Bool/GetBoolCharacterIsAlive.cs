using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Is Alive")]
    [Category("Characters/Is Alive")]
    
    [Image(typeof(IconSkull), ColorTheme.Type.Green)]
    [Description("Returns true if the Character is alive")]
    
    [Keywords("Character", "Living", "Life")]
    [Get]
    [Serializable]
    public class TypeBoolCharacterIsAlive : TypeBool
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        public override bool Get(Args args) => !this.m_Character.Get<Character>(args)?.IsDead ?? false;

        public TypeBoolCharacterIsAlive() : base()
        { }

        public static GetBool Create  => new GetBool(
            new TypeBoolCharacterIsAlive()
        );

        public override string ToString() => $"{this.m_Character} is Alive";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}