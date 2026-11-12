using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Is Player")]
    [Category("Characters/Is Player")]
    
    [Image(typeof(IconPlayer), ColorTheme.Type.Green)]
    [Description("Returns true if the Character is identified as the Player")]
    
    [Keywords("Character", "Controllable")]
    [Get]
    [Serializable]
    public class TypeBoolCharacterIsPlayer : TypeBool
    {
        [SerializeField]
        protected GetGameObject m_Character = TypeGameObjectSource.Create();

        public override bool Get(Args args) => this.m_Character.Get<Character>(args)?.IsPlayer ?? false;

        public TypeBoolCharacterIsPlayer() : base()
        { }

        public static GetBool Create  => new GetBool(
            new TypeBoolCharacterIsPlayer()
        );

        public override string ToString() => $"{this.m_Character} is Player";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}