using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Shot")]
    [Category("Cameras/Shot")]
    
    [Description("Reference to the game object with a Shot component")]
    [Image(typeof(IconCameraShot), ColorTheme.Type.Yellow)]

    [Get]

    [Serializable]
    public class TypeGameObjectShot : TypeGameObject
    {
        [SerializeField] private ShotCamera m_Shot;

        public override GameObject Get(Args args) => this.m_Shot != null
            ? this.m_Shot.gameObject 
            : null;

        public GameObject Get(GameObject gameObject) => this.m_Shot != null
            ? this.m_Shot.gameObject 
            : null;
        
        public override T Get<T>(Args args)
        {
            if (typeof(T) == typeof(ShotCamera)) return this.m_Shot as T;
            return base.Get<T>(args);
        }

        public static GetGameObject Create => new GetGameObject(
            new TypeGameObjectShot()
        );

        public override string ToString() => this.m_Shot != null 
            ? this.m_Shot.gameObject.name
            : "(none)";
        
        public override GameObject GetPreview(GameObject source) => this.EditorValue;

        public GameObject EditorValue => this.m_Shot != null 
            ? this.m_Shot.gameObject
            : null;
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}