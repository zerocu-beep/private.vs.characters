using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Hotspots
{
    [Title("On Hotspot Deactivate")]
    [Category("Logic/On Hotspot Deactivate")]
    [Description("Executed when its associated Hotspot is deactivated")]

    [Image(typeof(IconHotspot), ColorTheme.Type.Red)]
    [Keywords("Spot")]

    [Serializable]
    public class EventOnHotspotDeactivate : TriggerSourceComponentBase<Hotspot>
    {
        public EventOnHotspotDeactivate() : base(new TypeGameObjectSource())
        { }

        protected override string GetTitle(GameObject source)
        {
            string member = TextUtils.ThemeAsKeyword("Hotspot Deactivate");
            return $"{this.SourceName} {member}";
        }

        protected override void OnSourceChanged(Hotspot previousSource, Hotspot newSource)
        {
            if (previousSource != null) previousSource.EventOnDeactivate -= this.OnDeactivate;
            if (newSource != null) newSource.EventOnDeactivate += this.OnDeactivate;
        }

        private void OnDeactivate()
        {
            GameObject target = this.m_CurrentSource != null ? this.m_CurrentSource.gameObject : null;
            using Args args = Args.Get(this.Component, target);
            this.Run(args);
        }
    }
}
