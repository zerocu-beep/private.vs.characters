using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Is Dead")]
    [Category("Characters/Is Dead")]
    
    [Image(typeof(IconSkull), ColorTheme.Type.Red)]
    [Description("Returns true if the Character is dead")]
    
    [Keywords("Character", "Die")]
    [Get]
    [Serializable]
    public class TypeBoolCharacterIsDead : TypeBool
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        public override bool Get(Args args) => this.m_Character.Get<Character>(args)?.IsDead ?? false;

        public TypeBoolCharacterIsDead() : base()
        { }

        public static GetBool Create  => new GetBool(
            new TypeBoolCharacterIsDead()
        );

        public override string ToString() => $"{this.m_Character} is Dead";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}