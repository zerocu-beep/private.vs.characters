using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Main Shot")]
    [Category("Cameras/Main Shot")]
    
    [Image(typeof(IconCameraShot), ColorTheme.Type.Yellow, typeof(BadgeDot))]
    [Description("Reference to the current Main Camera Shot")]

    [Get]

    [Serializable]
    public class TypeGameObjectShotMain : TypeGameObject
    {
        public override GameObject Get(Args args)
        {
            return ShortcutMainShot.Instance;
        }

        public static GetGameObject Create => new GetGameObject(
            new TypeGameObjectShotMain()
        );

        public override string ToString() => "Main Shot";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}