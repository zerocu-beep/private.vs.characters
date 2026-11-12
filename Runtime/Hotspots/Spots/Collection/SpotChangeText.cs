using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Hotspots
{
    [Title("Change Text")]
    [Image(typeof(IconString), ColorTheme.Type.Yellow)]
    
    [Category("UI/Change Text")]
    [Description("Changes the chosen Text value")]

    [Serializable]
    public class SpotChangeText : Spot
    {
        // EXPOSED MEMBERS: -----------------------------------------------------------------------

        [SerializeField] protected SetString m_Change = new SetString(new GenTypeString_Text_Text());
        [SerializeField] protected GetString m_Text = new GetString();

        // PROPERTIES: ----------------------------------------------------------------------------

        public override string Title => $"Set {this.m_Change} = {this.m_Text}";

        // OVERRIDE METHODS: ----------------------------------------------------------------------

        public override void OnEnable(Hotspot hotspot)
        {
            base.OnEnable(hotspot);

            string text = this.m_Text.Get(hotspot.Args);
            this.m_Change.Set(text, hotspot.Args);
        }
    }
}