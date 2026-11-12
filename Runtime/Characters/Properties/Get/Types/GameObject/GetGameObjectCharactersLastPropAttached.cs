using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Last Prop Instance Attached")]
    [Category("Characters/Props/Last Prop Instance Attached")]
    
    [Image(typeof(IconTennis), ColorTheme.Type.Yellow, typeof(BadgePlus))]
    [Description("Reference to the latest Prop instance attached to a Character")]

    [Get]

    [Serializable]
    public class TypeGameObjectCharacterLastPropAttached : TypeGameObject
    {
        public override GameObject Get(Args args)
        {
            return Props.LastPropAttachedInstance;
        }

        public GameObject Get(GameObject gameObject)
        {
            return Props.LastPropAttachedInstance;
        }

        public override string ToString() => "Last Prop Attached";
        
        public static GetGameObject Create => new GetGameObject(
            new TypeGameObjectCharacterLastPropAttached()
        );
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}