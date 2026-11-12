using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Hotspots
{
    [Title("On Hotspot Activate")]
    [Category("Logic/On Hotspot Activate")]
    [Description("Executed when its associated Hotspot is activated")]

    [Image(typeof(IconHotspot), ColorTheme.Type.Green)]
    [Keywords("Spot")]

    [Serializable]
    public class EventOnHotspotActivate : TriggerSourceComponentBase<Hotspot>
    {
        public EventOnHotspotActivate() : base(new TypeGameObjectSource())
        { }

        protected override string GetTitle(GameObject source)
        {
            string member = TextUtils.ThemeAsKeyword("Hotspot Activate");
            return $"{this.SourceName} {member}";
        }

        protected override void OnSourceChanged(Hotspot previousSource, Hotspot newSource)
        {
            if (previousSource != null) previousSource.EventOnActivate -= this.OnActivate;
            if (newSource != null) newSource.EventOnActivate += this.OnActivate;
        }

        private void OnActivate()
        {
            GameObject target = this.m_CurrentSource != null ? this.m_CurrentSource.gameObject : null;
            using Args args = Args.Get(this.Component, target);
            this.Run(args);
        }
    }
}
