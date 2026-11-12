using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Character Model")]
    [Category("Characters/Character Model")]
    
    [Description("Game Object that represents the model of a Character (under Mannequin)")]
    [Image(typeof(IconCharacter), ColorTheme.Type.Yellow, typeof(BadgeArrowDown))]

    [Get]

    [Serializable]
    public class TypeGameObjectCharacterModel : TypeGameObject
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        
        public override GameObject Get(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null ? character.Animim.Animator.gameObject : null;
        }

        public GameObject Get(GameObject gameObject)
        {
            Character character = this.m_Character.Get<Character>(gameObject);
            return character != null && character.Animim.Animator != null
                ? character.Animim.Animator.gameObject
                : null;
        }

        public static GetGameObject Create()
        {
            TypeGameObjectCharacterModel instance = new TypeGameObjectCharacterModel();
            return new GetGameObject(instance);
        }

        public override string ToString() => $"{this.m_Character} Model";
        
        public override GameObject GetPreview(GameObject source) => this.EditorValue;

        public GameObject EditorValue
        {
            get
            {
                GameObject reference = this.m_Character.GetPreview(null);
                if (reference == null) return null;

                Character character = reference.GetComponent<Character>();
                if (character == null) return null;

                return character.Animim.Animator != null
                    ? character.Animim.Animator.gameObject
                    : null;
            }
        }
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}