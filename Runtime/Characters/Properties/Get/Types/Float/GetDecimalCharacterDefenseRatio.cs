using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Defense Ratio")]
    [Category("Characters/Combat/Defense Ratio")]
    
    [Image(typeof(IconShieldSolid), ColorTheme.Type.Yellow)]
    [Description("The Character's Defense ratio value")]

    [Keywords("Float", "Decimal", "Double", "Block", "Shield")]
    [Get]
    [Serializable]
    public class TypeNumberCharacterDefenseRatio : TypeNumber
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        public override double Get(Args args) => this.GetValue(args);

        private float GetValue(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null || character.Combat.MaximumDefense <= 0f) return 0f;

            float ratio = character.Combat.CurrentDefense / character.Combat.MaximumDefense;
            return Mathf.Clamp01(ratio);
        }

        public override string ToString() => $"{this.m_Character} Defense Ratio";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}