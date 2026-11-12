using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Hotspots
{
    using VisualScript.Runtime.Characters;

    [Title("Hotspot")]
    [Category("Visual Scripting/Hotspot")]
    
    [Image(typeof(IconHotspot), ColorTheme.Type.Yellow)]
    [Description("A Hotspot component reference")]

    [Get]

    [Serializable] [Inline(nameof(m_Hotspot), typeof(Hotspot), true)]
    public class TypeGameObjectHotspot : TypeGameObject
    {
        [SerializeField] protected Hotspot m_Hotspot;

        public override GameObject Get(Args args) => this.m_Hotspot != null 
            ? this.m_Hotspot.gameObject 
            : null;
        
        public GameObject Get(GameObject gameObject) => this.m_Hotspot != null 
            ? this.m_Hotspot.gameObject 
            : null;

        public override T Get<T>(Args args)
        {
            if (typeof(T) == typeof(Hotspot)) return this.m_Hotspot as T;
            return base.Get<T>(args);
        }

        public TypeGameObjectHotspot() : base()
        { }

        public TypeGameObjectHotspot(GameObject gameObject) : this()
        {
            this.m_Hotspot = gameObject.Get<Hotspot>();
        }
        
        public TypeGameObjectHotspot(Hotspot hotspot) : this()
        {
            this.m_Hotspot = hotspot;
        }

        public static GetGameObject Create()
        {
            TypeGameObjectHotspot instance = new TypeGameObjectHotspot();
            return new GetGameObject(instance);
        }

        public override string ToString() => this.m_Hotspot != null
            ? this.m_Hotspot.gameObject.name
            : "(none)";

        public override GameObject GetPreview(GameObject source) => this.EditorValue;

        public GameObject EditorValue => this.m_Hotspot != null 
            ? this.m_Hotspot.gameObject
            : null;
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}