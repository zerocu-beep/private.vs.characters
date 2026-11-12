using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Last Prop Instance Detached")]
    [Category("Characters/Props/Last Prop Instance Detached")]
    
    [Image(typeof(IconTennis), ColorTheme.Type.Yellow, typeof(BadgeMinus))]
    [Description("Reference to the latest Prop instance detached from a Character")]

    [Get]

    [Serializable]
    public class TypeGameObjectCharacterLastPropDetached : TypeGameObject
    {
        public override GameObject Get(Args args)
        {
            return Props.LastPropDetachedInstance;
        }

        public GameObject Get(GameObject gameObject)
        {
            return Props.LastPropDetachedInstance;
        }

        public override string ToString() => "Last Prop Attached";
        
        public static GetGameObject Create => new GetGameObject(
            new TypeGameObjectCharacterLastPropDetached()
        );
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}