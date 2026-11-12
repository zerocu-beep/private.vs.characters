using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Character Position Feet")]
    [Category("Characters/Character Position Feet")]
    
    [Image(typeof(IconCharacter), ColorTheme.Type.Yellow, typeof(BadgeArrowDown))]
    [Description("Returns the bottom (feet) position of the Character")]

    [Get]

    [Serializable]
    public class TypeVector3PositionCharacterBottom : TypeVector3
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        public TypeVector3PositionCharacterBottom()
        { }

        public TypeVector3PositionCharacterBottom(Character character)
        {
            this.m_Character = TypeGameObjectCharacterInstance.CreateWith(character);
        }

        public override Vector3 Get(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null ? character.Feet : default;
        }

        public static GetVector3 Create => new GetVector3(
            new TypeVector3PositionCharacterBottom()
        );
        
        public static GetVector3 CreateWith(Character character)
        {
            return new GetVector3(
                new TypeVector3PositionCharacterBottom(character)
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
                return character != null ? character.Feet : default;
            }
        }

        public override string ToString() => $"{this.m_Character} Feet";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}