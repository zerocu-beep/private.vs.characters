using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Character Bone Position")]
    [Category("Characters/Character Bone Position")]
    
    [Image(typeof(IconBoneSolid), ColorTheme.Type.Yellow)]
    [Description("The bone position of a Character game object")]

    [Get]

    [Serializable]
    public class TypeVector3PositionCharacterBone : TypeVector3
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        
        [SerializeField] private Bone m_Bone = new Bone(HumanBodyBones.RightHand); 

        public TypeVector3PositionCharacterBone()
        { }

        public TypeVector3PositionCharacterBone(GetGameObject character, Bone bone)
        {
            this.m_Character = character;
            this.m_Bone = bone;
        }

        public override Vector3 Get(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null || character.Animim?.Animator == null) return default;

            GameObject bone = this.m_Bone.Get(character.Animim?.Animator);
            return bone != null ? bone.transform.position : default;
        }

        public static GetVector3 Create()
        {
            return new GetVector3(
                new TypeVector3PositionCharacterBone()
            );
        }

        public static GetVector3 Create(GetGameObject character, Bone bone)
        {
            return new GetVector3(
                new TypeVector3PositionCharacterBone(character, bone)
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
                if (character == null) return default;

                Animator animator = character.Animim?.Animator;
                if (animator == null) return default;

                Transform bone = this.m_Bone.GetTransform(animator);
                return bone != null ? bone.position : default;
            }
        }

        public override string ToString() => $"{this.m_Character}/{this.m_Bone}";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}