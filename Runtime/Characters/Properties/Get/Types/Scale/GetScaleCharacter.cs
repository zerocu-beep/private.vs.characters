using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Character Scale")]
    [Category("Characters/Character Scale")]
    
    [Image(typeof(IconCharacter), ColorTheme.Type.Yellow)]
    [Description("Scale of the Character game object in local or world space")]

    [Get]

    [Serializable]
    public class TypeVector3ScaleCharacter : TypeVector3
    {
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        
        [SerializeField] 
        private ScaleSpace m_Space = ScaleSpace.Local;

        public override Vector3 Get(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Vector3.one;
            
            return this.m_Space switch
            {
                ScaleSpace.Local => character.transform.localScale,
                ScaleSpace.Global => character.transform.lossyScale,
                _ => throw new ArgumentOutOfRangeException()
            };   
        }

        public static GetVector3 Create => new GetVector3(
            new TypeVector3ScaleCharacter()
        );

        public override string ToString() => $"{this.m_Space} {this.m_Character}";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}