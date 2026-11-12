using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Local Input Direction")]
    [Category("Characters/Local Input Direction")]
    
    [Image(typeof(IconGamepadCross), ColorTheme.Type.Yellow, typeof(BadgeArrowRight))]
    [Description("The raw desired input direction of the Character in local space")]
    
    [Get]
    
    [Serializable]
    public class TypeVector3DirectionCharacterLocalInput : TypeVector3
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        
        public override Vector3 Get(Args args) => this.GetDirection(args);

        private Vector3 GetDirection(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null ? character.Player.LocalInputDirection : default;
        }
        
        public static GetVector3 Create => new GetVector3(
            new TypeVector3DirectionCharacterLocalInput()
        );
        
        public override string ToString() => $"{this.m_Character} Local Input";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}