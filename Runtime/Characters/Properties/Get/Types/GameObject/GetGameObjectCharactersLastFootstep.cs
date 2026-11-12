using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Character Last Footstep")]
    [Category("Characters/Character Last Footstep")]
    
    [Description("Game Object bone that represents the Character's last foot step")]
    [Image(typeof(IconFootprint), ColorTheme.Type.Yellow)]

    [Get]

    [Serializable]
    public class TypeGameObjectCharacterLastFootstep : TypeGameObject
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        
        public override GameObject Get(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null ? character.Footsteps.LastFootstep : null;
        }

        public static GetGameObject Create()
        {
            TypeGameObjectCharacterLastFootstep instance = new TypeGameObjectCharacterLastFootstep();
            return new GetGameObject(instance);
        }

        public override string ToString() => $"{this.m_Character} Footstep";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}