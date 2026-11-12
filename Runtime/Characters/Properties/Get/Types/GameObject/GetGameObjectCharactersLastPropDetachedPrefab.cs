using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Last Prop Prefab Detached")]
    [Category("Characters/Props/Last Prop Prefab Detached")]
    
    [Image(typeof(IconTennis), ColorTheme.Type.Blue, typeof(BadgeMinus))]
    [Description("Reference to the latest Prop instance detached from a Character")]

    [Get]

    [Serializable]
    public class TypeGameObjectCharacterLastPropDetachedPrefab : TypeGameObject
    {
        public override GameObject Get(Args args)
        {
            return Props.LastPropDetachedPrefab;
        }

        public GameObject Get(GameObject gameObject)
        {
            return Props.LastPropDetachedPrefab;
        }

        public override string ToString() => "Last Prop Attached";
        
        public static GetGameObject Create => new GetGameObject(
            new TypeGameObjectCharacterLastPropDetachedPrefab()
        );
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}