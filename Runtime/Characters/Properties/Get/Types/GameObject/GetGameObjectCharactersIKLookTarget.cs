using System;
using VisualScript.Runtime.Characters.IK;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Character Look Target")]
    [Category("Characters/IK/Character Look Target")]
    
    [Image(typeof(IconIK), ColorTheme.Type.Yellow)]
    [Description("Reference to the IK Look Target by a Character (if any)")]

    [Get]

    [Serializable]
    public class TypeGameObjectCharacterIKLookTarget : TypeGameObject
    {
        [SerializeField] protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        
        public override GameObject Get(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null
                ? character.IK.GetRig<RigLookTo>()?.LookToTarget.Target
                : null;
        }

        public GameObject Get(GameObject gameObject)
        {
            Character character = this.m_Character.Get<Character>(gameObject);
            return character != null
                ? character.IK.GetRig<RigLookTo>()?.LookToTarget.Target
                : null;
        }

        public override string ToString() => $"{this.m_Character} Look Target";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}