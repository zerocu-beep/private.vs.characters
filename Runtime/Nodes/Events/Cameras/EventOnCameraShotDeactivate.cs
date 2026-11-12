using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Cameras
{
    [Title("On Shot Deactivate")]
    [Category("Cameras/On Shot Deactivate")]
    [Description("Executed when a Camera stops using this Camera Shot")]

    [Image(typeof(IconCameraShot), ColorTheme.Type.Red, typeof(BadgeArrowLeft))]
    [Keywords("Shot", "Switch", "Cut", "Exit")]

    [Serializable]
    public class EventOnCameraShotDeactivate : TriggerSourceComponentBase<ShotCamera>
    {
        public EventOnCameraShotDeactivate() : base(new TypeGameObjectSource())
        { }

        protected override string GetTitle(GameObject source)
        {
            string member = TextUtils.ThemeAsKeyword("Shot Deactivate");
            return $"{this.SourceName} {member}";
        }

        protected override void OnSourceChanged(ShotCamera previousSource, ShotCamera newSource)
        {
            if (previousSource != null) previousSource.EventChangeFrom -= this.OnChange;
            if (newSource != null) newSource.EventChangeFrom += this.OnChange;
        }

        private void OnChange(TCamera camera)
        {
            using Args args = Args.Get(this.Component, camera != null ? camera.gameObject : null);
            this.Run(args);
        }
    }
}
