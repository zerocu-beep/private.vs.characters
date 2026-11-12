using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Player")]
    [Category("Characters/Player")]
    
    [Description("Game Object that represents the Player")]
    [Image(typeof(IconPlayer), ColorTheme.Type.Green)]

    [Get]

    [Serializable]
    public class TypeGameObjectPlayer : TypeGameObject
    {
        public override GameObject Get(Args args)
        {
            return ShortcutPlayer.Instance != null 
                ? ShortcutPlayer.Instance.gameObject
                : null;
        }

        public GameObject Get(GameObject gameObject)
        {
            return ShortcutPlayer.Instance != null 
                ? ShortcutPlayer.Instance.gameObject
                : null;
        }

        public static GetGameObject Create()
        {
            TypeGameObjectPlayer instance = new TypeGameObjectPlayer();
            return new GetGameObject(instance);
        }

        public override string ToString() => "Player";
        
        public override GameObject GetPreview(GameObject source) => this.EditorValue;

        public GameObject EditorValue
        {
            get
            {
                Character[] instances = UnityEngine.Object.FindObjectsByType<Character>();
                foreach (Character instance in instances)
                {
                    if (instance.IsPlayer) return instance.gameObject;
                }

                return null;
            }
        }
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}