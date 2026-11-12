using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Defense Maximum")]
    [Category("Characters/Combat/Defense Maximum")]
    
    [Image(typeof(IconShieldSolid), ColorTheme.Type.Yellow)]
    [Description("The Character's maximum Defense value")]

    [Keywords("Float", "Decimal", "Double", "Block", "Shield")]
    [Get]
    [Serializable]
    public class TypeNumberCharacterDefenseMaximum : TypeNumber
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        public override double Get(Args args) => this.GetValue(args);

        private float GetValue(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null ? character.Combat.MaximumDefense : 0f;
        }

        public override string ToString() => $"{this.m_Character} Max Defense";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}