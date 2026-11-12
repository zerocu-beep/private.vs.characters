using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Camera")]
    [Category("Cameras/Camera")]
    
    [Description("Reference to the game object with a Camera component")]
    [Image(typeof(IconCamera), ColorTheme.Type.Green)]
    
    [Get]
    
    [Serializable]
    public class TypeGameObjectCamera : TypeGameObject
    {
        [SerializeField] private Camera m_Camera;

        public override GameObject Get(Args args) => this.m_Camera != null
            ? this.m_Camera.gameObject 
            : null;

        public GameObject Get(GameObject gameObject) => this.m_Camera != null
        ? this.m_Camera.gameObject 
        : null;
        
        public override T Get<T>(Args args)
        {
            if (typeof(T) == typeof(Camera)) return this.m_Camera as T;
            return base.Get<T>(args);
        }

        public static GetGameObject Create => new GetGameObject(
            new TypeGameObjectCamera()
        );

        public override string ToString() => this.m_Camera != null 
            ? this.m_Camera.gameObject.name
            : "(none)";
        
        public override GameObject GetPreview(GameObject source) => this.EditorValue;

        public GameObject EditorValue => this.m_Camera != null 
            ? this.m_Camera.gameObject
            : null;
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}