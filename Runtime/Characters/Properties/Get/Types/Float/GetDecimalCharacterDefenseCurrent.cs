using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Defense Current")]
    [Category("Characters/Combat/Defense Current")]
    
    [Image(typeof(IconShieldSolid), ColorTheme.Type.Yellow)]
    [Description("The Character's Defense value")]

    [Keywords("Float", "Decimal", "Double", "Block", "Shield")]
    [Get]
    [Serializable]
    public class TypeNumberCharacterDefenseCurrent : TypeNumber
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        public override double Get(Args args) => this.GetValue(args);

        private float GetValue(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null ? character.Combat.CurrentDefense : 0f;
        }

        public override string ToString() => $"{this.m_Character} Defense";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}