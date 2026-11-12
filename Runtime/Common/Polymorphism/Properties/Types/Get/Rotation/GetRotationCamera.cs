using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Camera")]
    [Category("Cameras/Camera")]
    
    [Image(typeof(IconCamera), ColorTheme.Type.Green)]
    [Description("Rotation of the selected Camera in world space")]

    [Get]

    [Serializable]
    public class TypeQuaternionRotationCamera : TypeQuaternion
    {
        [SerializeField] private GetGameObject m_Camera = new GetGameObject(new TypeGameObjectCameraMain());
        
        public override Quaternion Get(Args args)
        {
            TCamera camera = this.m_Camera.Get<TCamera>(args);
            return camera != null ? camera.transform.rotation : default;
        }

        public static GetQuaternion Create => new GetQuaternion(
            new TypeQuaternionRotationCamera()
        );

        public override string ToString() => this.m_Camera.ToString();
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}