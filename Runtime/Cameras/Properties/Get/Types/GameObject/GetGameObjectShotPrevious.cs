using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Previous Shot")]
    [Category("Cameras/Previous Shot")]
    
    [Image(typeof(IconCameraShot), ColorTheme.Type.Yellow, typeof(BadgeArrowLeft))]
    [Description("Reference to the previous Camera Shot used by a Camera")]

    [Get]

    [Serializable]
    public class TypeGameObjectShotPrevious : TypeGameObject
    {
        [SerializeField]
        protected GetGameObject m_Camera = new GetGameObject(new TypeGameObjectCameraMain());

        public override GameObject Get(Args args)
        {
            TCamera camera = this.m_Camera.Get<TCamera>(args);
            ShotCamera shot = camera != null ? camera.Transition.PreviousShotCamera : null;

            return shot != null ? shot.gameObject : null;
        }

        public static GetGameObject Create => new GetGameObject(
            new TypeGameObjectShotPrevious()
        );

        public override string ToString() => $"{this.m_Camera} Previous Shot";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}