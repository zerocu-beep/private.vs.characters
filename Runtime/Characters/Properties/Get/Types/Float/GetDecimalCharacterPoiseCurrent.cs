using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Poise")]
    [Category("Characters/Combat/Poise")]
    
    [Image(typeof(IconShieldOutline), ColorTheme.Type.Yellow)]
    [Description("The Character's Poise value")]

    [Keywords("Float", "Decimal", "Double", "Poise")]
    [Get]
    [Serializable]
    public class TypeNumberCharacterPoiseCurrent : TypeNumber
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        public override double Get(Args args) => this.GetValue(args);

        private float GetValue(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null ? character.Combat.Poise.Current : 0f;
        }

        public override string ToString() => $"{this.m_Character} Poise";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}