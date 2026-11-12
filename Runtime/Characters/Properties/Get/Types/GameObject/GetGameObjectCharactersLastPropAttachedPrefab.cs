using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Last Prop Prefab Attached")]
    [Category("Characters/Props/Last Prop Prefab Attached")]
    
    [Image(typeof(IconTennis), ColorTheme.Type.Blue, typeof(BadgePlus))]
    [Description("Reference to the latest Prop prefab used to instantiate the attachment to a Character")]

    [Get]

    [Serializable]
    public class TypeGameObjectCharacterLastPropAttachedPrefab : TypeGameObject
    {
        public override GameObject Get(Args args)
        {
            return Props.LastPropAttachedPrefab;
        }

        public GameObject Get(GameObject gameObject)
        {
            return Props.LastPropAttachedPrefab;
        }

        public override string ToString() => "Last Prop Attached";
        
        public static GetGameObject Create => new GetGameObject(
            new TypeGameObjectCharacterLastPropAttachedPrefab()
        );
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}