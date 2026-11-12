using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Main Shot")]
    [Category("Cameras/Main Shot")]
    
    [Image(typeof(IconCameraShot), ColorTheme.Type.Yellow)]
    [Description("Returns the position of the main Camera Shot object")]

    [Get]

    [Serializable]
    public class TypeVector3PositionCamerasMainShot : TypeVector3
    {
        public override Vector3 Get(Args args)
        {
            Transform transform = ShortcutMainShot.Transform;
            return transform != null ? transform.position : default;
        }
        
        public Vector3 Get(GameObject gameObject)
        {
            Transform transform = ShortcutMainShot.Transform;
            return transform != null ? transform.position : default;
        }

        public static GetVector3 Create => new GetVector3(
            new TypeVector3PositionCamerasMainShot()
        );

        public override string ToString() => "Main Shot";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}