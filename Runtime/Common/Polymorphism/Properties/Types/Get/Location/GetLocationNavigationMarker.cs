using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Marker")]
    [Category("Navigation/Marker")]
    
    [Image(typeof(IconMarker), ColorTheme.Type.Yellow)]
    [Description("The position and rotation of a Marker component")]

    [Get]

    [Serializable]
    public class TypeLocationNavigationMarker : TypeLocation
    {
        [SerializeField]
        private GetGameObject m_Marker = new GetGameObject(new TypeGameObjectNavigationMarker());

        public override Location Get(Args args)
        {
            return new Location(this.m_Marker.Get<Marker>(args));
        }

        public static GetLocation Create => new GetLocation(
            new TypeLocationNavigationMarker()
        );
        
        public override string ToString() => this.m_Marker.ToString();
    }
}