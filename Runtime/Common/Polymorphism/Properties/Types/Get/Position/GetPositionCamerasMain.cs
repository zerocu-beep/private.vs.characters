using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    using VisualScript.Runtime.Characters;

    [Title("Main Camera")]
    [Category("Cameras/Main Camera")]
    
    [Image(typeof(IconCamera), ColorTheme.Type.Green)]
    [Description("Returns the position of the Main Camera object")]

    [Get]

    [Serializable]
    public class TypeVector3PositionCamerasMain : TypeVector3
    {
        public override Vector3 Get(Args args)
        {
            Transform transform = ShortcutMainCamera.Transform;
            return transform != null ? transform.position : default;
        }
        
        public Vector3 Get(GameObject gameObject)
        {
            Transform transform = ShortcutMainCamera.Transform;
            return transform != null ? transform.position : default;
        }

        public static GetVector3 Create => new GetVector3(
            new TypeVector3PositionCamerasMain()
        );

        public override string ToString() => "Main Camera";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}