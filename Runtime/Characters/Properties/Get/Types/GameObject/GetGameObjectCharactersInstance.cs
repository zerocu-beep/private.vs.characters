using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Character")]
    [Category("Characters/Character")]
    
    [Image(typeof(IconCharacter), ColorTheme.Type.Yellow)]
    [Description("Reference to a Character game object")]

    [Get]

    [Serializable] [Inline(nameof(m_Character), typeof(Character), true)]
    public class TypeGameObjectCharacterInstance : TypeGameObject
    {
        [SerializeField] private Character m_Character;

        public TypeGameObjectCharacterInstance()
        { }

        public TypeGameObjectCharacterInstance(Character character)
        {
            this.m_Character = character;
        }

        public override GameObject Get(Args args)
        {
            return this.m_Character != null ? this.m_Character.gameObject : null;
        }

        public GameObject Get(GameObject gameObject)
        {
            return this.m_Character != null ? this.m_Character.gameObject : null;
        }

        public static GetGameObject Create => new GetGameObject(
            new TypeGameObjectCharacterInstance()
        );

        public static GetGameObject CreateWith(Character character)
        {
            return new GetGameObject(
                new TypeGameObjectCharacterInstance(character)
            );
        }

        public override string ToString() => this.m_Character != null
            ? this.m_Character.gameObject.name
            : "(none)";

        public override GameObject GetPreview(GameObject source) => this.EditorValue;

        public GameObject EditorValue => this.m_Character != null
            ? this.m_Character.gameObject 
            : null;
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}