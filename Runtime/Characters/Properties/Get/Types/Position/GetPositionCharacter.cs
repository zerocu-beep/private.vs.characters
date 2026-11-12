using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Character Position")]
    [Category("Characters/Character Position")]
    
    [Image(typeof(IconCharacter), ColorTheme.Type.Yellow)]
    [Description("Returns the position of the Character")]

    [Get]

    [Serializable]
    public class TypeVector3PositionCharacter : TypeVector3
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        public TypeVector3PositionCharacter()
        { }

        public TypeVector3PositionCharacter(Character character)
        {
            this.m_Character = TypeGameObjectCharacterInstance.CreateWith(character);
        }

        public override Vector3 Get(Args args)
        {
            Transform character = this.m_Character.Get<Transform>(args);
            return character != null ? character.position : default;
        }

        public static GetVector3 Create => new GetVector3(
            new TypeVector3PositionCharacter()
        );
        
        public static GetVector3 CreateWith(Character character)
        {
            return new GetVector3(
                new TypeVector3PositionCharacter(character)
            );
        }

        public override Vector3 GetPreview(GameObject source) => this.EditorValue;

        public Vector3 EditorValue
        {
            get
            {
                GameObject character = this.m_Character.GetPreview(null);
                return character != null ? character.transform.position : default;
            }
        }

        public override string ToString() => this.m_Character.ToString();
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}