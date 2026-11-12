using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Character Rotation")]
    [Category("Characters/Character Rotation")]
    
    [Image(typeof(IconCharacter), ColorTheme.Type.Yellow)]
    [Description("Rotation of the Character in local or world space")]

    [Get]

    [Serializable]
    public class TypeQuaternionRotationCharacter : TypeQuaternion
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        
        [SerializeField] 
        private RotationSpace m_Space = RotationSpace.Global;
        
        public override Quaternion Get(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return default;

            return this.m_Space switch
            {
                RotationSpace.Local => character.transform.localRotation,
                RotationSpace.Global => character.transform.rotation,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public static GetQuaternion Create => new GetQuaternion(
            new TypeQuaternionRotationCharacter()
        );

        public override string ToString() => $"{this.m_Space} {this.m_Character}";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}