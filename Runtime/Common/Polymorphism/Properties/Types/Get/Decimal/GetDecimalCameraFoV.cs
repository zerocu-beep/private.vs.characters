using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Field of View")]
    [Category("Camera/Field of View")]
    
    [Image(typeof(IconCamera), ColorTheme.Type.Yellow)]
    [Description("The targeted camera's field of view")]

    [Keywords("FOV", "Aperture", "Angle", "Cone", "View")]
    
    [Get]
    
    [Serializable]
    public class TypeNumberCameraFoV : TypeNumber
    {
        [SerializeField] private GetGameObject m_Camera = new GetGameObject(new TypeGameObjectCameraMain());
        
        public override double Get(Args args) => this.GetValue(args);

        private double GetValue(Args args)
        {
            Camera camera = this.m_Camera.Get<Camera>(args);
            return camera != null ? camera.fieldOfView : 0;
        }

        public static GetNumber Create => new GetNumber(
            new TypeNumberCameraFoV()
        );

        public override string ToString() => $"{m_Camera} FoV";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}