using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Poise Ratio")]
    [Category("Characters/Combat/Poise Ratio")]
    
    [Image(typeof(IconShieldOutline), ColorTheme.Type.Yellow)]
    [Description("The Character's Poise ratio between the current value and its maximum")]

    [Keywords("Float", "Decimal", "Double", "Poise")]
    [Get]
    [Serializable]
    public class TypeNumberCharacterPoiseRatio : TypeNumber
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        public override double Get(Args args) => this.GetValue(args);

        private float GetValue(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null ? character.Combat.Poise.Ratio : 0f;
        }

        public override string ToString() => $"{this.m_Character} Poise Ratio";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}