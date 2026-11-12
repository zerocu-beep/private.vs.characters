using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Cameras
{
    using VisualScript.Runtime.Characters;

    [Title("On Camera Change")]
    [Category("Cameras/On Camera Change")]
    [Description("Executed when the Camera changes to another Camera Shot")]

    [Image(typeof(IconCamera), ColorTheme.Type.Green)]
    [Keywords("Shot", "Switch", "Cut")]

    [Serializable]
    public class EventOnCameraChange : TriggerSourceComponentBase<TCamera>
    {
        private enum ChangeMode
        {
            AnyChange,
            OnCut,
            OnTransition
        }

        [SerializeField] private ChangeMode m_When = ChangeMode.AnyChange;

        public EventOnCameraChange() : base(new TypeGameObjectCameraMain())
        { }

        protected override string GetTitle(GameObject source)
        {
            string member = TextUtils.ThemeAsKeyword("Camera Change");
            return $"{this.SourceName} {member}";
        }

        protected override void OnSourceChanged(TCamera previousSource, TCamera newSource)
        {
            if (previousSource != null)
            {
                previousSource.EventCut -= this.OnChangeCut;
                previousSource.EventTransition -= this.OnChangeTransition;
            }

            if (newSource != null)
            {
                newSource.EventCut += this.OnChangeCut;
                newSource.EventTransition += this.OnChangeTransition;
            }
        }

        private void OnChangeCut(ShotCamera shotCamera)
        {
            if (this.m_When == ChangeMode.OnTransition) return;
            this.Execute(shotCamera);
        }

        private void OnChangeTransition(ShotCamera shotCamera, float duration, Easing.Type ease)
        {
            if (this.m_When == ChangeMode.OnCut) return;
            this.Execute(shotCamera);
        }

        private void Execute(ShotCamera shotCamera)
        {
            using Args args = Args.Get(this.Component, shotCamera != null ? shotCamera.gameObject : null);
            this.Run(args);
        }
    }
}
