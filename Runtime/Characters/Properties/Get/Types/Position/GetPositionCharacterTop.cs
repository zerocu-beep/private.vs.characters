using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Character Position Head")]
    [Category("Characters/Character Position Head")]
    
    [Image(typeof(IconCharacter), ColorTheme.Type.Yellow, typeof(BadgeArrowUp))]
    [Description("Returns the top (head) position of the Character")]

    [Get]

    [Serializable]
    public class TypeVector3PositionCharacterTop : TypeVector3
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        public TypeVector3PositionCharacterTop()
        { }

        public TypeVector3PositionCharacterTop(Character character)
        {
            this.m_Character = TypeGameObjectCharacterInstance.CreateWith(character);
        }

        public override Vector3 Get(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null ? character.Crown : default;
        }

        public static GetVector3 Create => new GetVector3(
            new TypeVector3PositionCharacterTop()
        );
        
        public static GetVector3 CreateWith(Character character)
        {
            return new GetVector3(
                new TypeVector3PositionCharacterTop(character)
            );
        }

        public override Vector3 GetPreview(GameObject source) => this.EditorValue;

        public Vector3 EditorValue
        {
            get
            {
                GameObject gameObject = this.m_Character.GetPreview(null);
                if (gameObject == null) return default;

                Character character = gameObject.GetComponent<Character>();
                return character != null ? character.Crown : default;
            }
        }

        public override string ToString() => $"{this.m_Character} Head";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}