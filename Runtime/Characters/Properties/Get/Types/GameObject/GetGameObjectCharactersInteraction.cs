using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Character Interaction")]
    [Category("Characters/Character Interaction")]
    
    [Image(typeof(IconCharacterInteract), ColorTheme.Type.Yellow)]
    [Description("Reference to the Interactive element selected by a Character")]

    [Get]

    [Serializable]
    public class TypeGameObjectCharacterInteraction : TypeGameObject
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        public override GameObject Get(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            return character != null 
                ? character.Interaction.Target?.Instance 
                : null;
        }

        public GameObject Get(GameObject gameObject)
        {
            Character character = this.m_Character.Get<Character>(gameObject);
            return character != null 
                ? character.Interaction.Target?.Instance 
                : null;
        }

        public override string ToString() => $"{this.m_Character} Interaction";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}