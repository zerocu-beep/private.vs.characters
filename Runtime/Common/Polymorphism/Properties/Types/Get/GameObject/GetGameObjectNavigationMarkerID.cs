using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Marker by ID")]
    [Category("Navigation/Marker by ID")]
    
    [Image(typeof(IconID), ColorTheme.Type.TextNormal)]
    [Description("Reference to a scene Marker game object by its ID")]

    [Get]

    [Serializable]
    public class TypeGameObjectNavigationMarkerID : TypeGameObject
    {
        [SerializeField] 
        private GetString m_ID = new GetString();

        public override GameObject Get(Args args) => this.GetObject(args);

        private GameObject GetObject(Args args)
        {
            string id = this.m_ID.Get(args);
            Marker marker = Marker.GetMarkerByID(id);
            
            return marker != null ? marker.gameObject : null;
        }

        public static GetGameObject Create()
        {
            TypeGameObjectNavigationMarkerID instance = new TypeGameObjectNavigationMarkerID();
            return new GetGameObject(instance);
        }

        public override string ToString() => $"Marker ID:{this.m_ID}";
        
        public override GameObject GetPreview(GameObject source) => this.EditorValue;

        public GameObject EditorValue
        {
            get
            {
                Marker[] instances = UnityEngine.Object.FindObjectsByType<Marker>();
                
                string id = this.m_ID.ToString();
                if (string.IsNullOrEmpty(id)) return null;
                
                int hash = id.GetHashCode();
                foreach (Marker instance in instances)
                {
                    ISpatialHash spatialHash = instance;
                    if (spatialHash.UniqueCode == hash) return instance.gameObject;
                }

                return null;
            }
        }
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}