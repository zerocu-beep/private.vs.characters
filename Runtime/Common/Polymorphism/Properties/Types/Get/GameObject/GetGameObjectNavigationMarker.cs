using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Marker")]
    [Category("Navigation/Marker")]
    
    [Image(typeof(IconMarker), ColorTheme.Type.Yellow)]
    [Description("Reference to a scene Marker game object")]

    [Get]

    [Serializable][Inline(nameof(m_Marker), typeof(Marker), true)]
    public class TypeGameObjectNavigationMarker : TypeGameObject
    {
        [SerializeField] private Marker m_Marker;

        public override GameObject Get(Args args) => this.m_Marker != null
            ? this.m_Marker.gameObject
            : null;

        public GameObject Get(GameObject gameObject) => this.m_Marker != null
            ? this.m_Marker.gameObject
            : null;
        
        public override T Get<T>(Args args)
        {
            if (typeof(T) == typeof(Marker)) return this.m_Marker as T;
            return base.Get<T>(args);
        }

        public static GetGameObject Create()
        {
            TypeGameObjectNavigationMarker instance = new TypeGameObjectNavigationMarker();
            return new GetGameObject(instance);
        }

        public override string ToString() => this.m_Marker != null
            ? this.m_Marker.gameObject.name
            : "(none)";

        public override GameObject GetPreview(GameObject source) => this.EditorValue;

        public GameObject EditorValue => this.m_Marker != null
            ? this.m_Marker.gameObject
            : null;
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}