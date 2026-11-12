using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Cameras
{
    [Title("On Shot Activate")]
    [Category("Cameras/On Shot Activate")]
    [Description("Executed when a Camera starts using this Camera Shot")]

    [Image(typeof(IconCameraShot), ColorTheme.Type.Green, typeof(BadgeArrowRight))]
    [Keywords("Shot", "Switch", "Cut", "Enter")]

    [Serializable]
    public class EventOnCameraShotActivate : TriggerSourceComponentBase<ShotCamera>
    {
        public EventOnCameraShotActivate() : base(new TypeGameObjectSource())
        { }

        protected override string GetTitle(GameObject source)
        {
            string member = TextUtils.ThemeAsKeyword("Shot Activate");
            return $"{this.SourceName} {member}";
        }

        protected override void OnSourceChanged(ShotCamera previousSource, ShotCamera newSource)
        {
            if (previousSource != null) previousSource.EventChangeTo -= this.OnChange;
            if (newSource != null) newSource.EventChangeTo += this.OnChange;
        }

        private void OnChange(TCamera camera)
        {
            using Args args = Args.Get(this.Component, camera != null ? camera.gameObject : null);
            this.Run(args);
        }
    }
}
