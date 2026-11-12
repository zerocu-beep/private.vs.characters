using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Character Bone")]
    [Category("Characters/Character Bone")]
    
    [Image(typeof(IconBoneSolid), ColorTheme.Type.Yellow)]
    [Description("The bone references on a Character game object")]

    [Get]

    [Serializable]
    public class TypeGameObjectCharacterBone : TypeGameObject
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        
        [SerializeField] private Bone m_Bone = new Bone(HumanBodyBones.RightHand);
        
        public override GameObject Get(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return null;
            
            return character.Animim?.Animator != null 
                ? this.m_Bone.Get(character.Animim?.Animator) 
                : null;
        }

        public TypeGameObjectCharacterBone(GetGameObject character, Bone bone)
        {
            this.m_Character = character;
            this.m_Bone = bone;
        }

        public TypeGameObjectCharacterBone()
        {
            
        }
        
        public static GetGameObject Create(GetGameObject character, Bone bone)
        {
            return new GetGameObject(
                new TypeGameObjectCharacterBone(character, bone)
            );
        }
        
        public override GameObject GetPreview(GameObject source) => this.EditorValue;

        public GameObject EditorValue
        {
            get
            {
                GameObject gameObject = this.m_Character.GetPreview(null);
                if (gameObject == null) return null;

                Character character = gameObject.GetComponent<Character>();
                if (character == null) return null;

                Animator animator = character.Animim?.Animator;
                if (animator == null) return null;
                
                Transform bone = this.m_Bone.GetTransform(animator);
                return bone != null ? bone.gameObject : null;
            }
        }

        public override string ToString() => $"{this.m_Character}/{this.m_Bone}";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}