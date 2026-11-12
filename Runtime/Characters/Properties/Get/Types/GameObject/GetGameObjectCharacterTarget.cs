using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Character Target")]
    [Category("Characters/Combat/Character Target")]
    
    [Description("Game Object targeted by the specified Character")]
    [Image(typeof(IconBullsEye), ColorTheme.Type.Yellow)]

    [Get]

    [Serializable]
    public class TypeGameObjectCharacterTarget : TypeGameObject
    {
        [SerializeField] private GetGameObject m_From = new GetGameObject(new TypeGameObjectPlayer());
        
        public override GameObject Get(Args args)
        {
            Character character = this.m_From.Get<Character>(args);
            return character != null ? character.Combat.Targets.Primary : null;
        }

        public GameObject Get(GameObject gameObject)
        {
            Character character = this.m_From.Get<Character>(gameObject);
            return character != null ? character.Combat.Targets.Primary : null;
        }

        public static GetGameObject Create()
        {
            TypeGameObjectCharacterTarget instance = new TypeGameObjectCharacterTarget();
            return new GetGameObject(instance);
        }

        public override string ToString() => $"{this.m_From} Target";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}