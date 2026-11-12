using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Track Target")]
    [Category("Tracking/Track Target")]
    
    [Image(typeof(IconCubeSolid), ColorTheme.Type.Yellow, typeof(BadgeArrowRight))]
    [Description("A translation towards a specific target and an optional rotation")]
    
    [Keywords("Track", "Follow", "Towards", "Away")]
    
    [Get]
    
    [Serializable]
    public class TypeLocationTrackLocation : TTypeLocationTrack
    {
        [SerializeField] private GetGameObject m_From = TypeGameObjectSource.Create();
        [SerializeField] private GetGameObject m_To = TypeGameObjectTarget.Create();
        
        public static GetLocation Create()
        {
            TypeLocationTrackLocation instance = new TypeLocationTrackLocation();
            return new GetLocation(instance);
        }
        
        public override string ToString() => $"{this.m_From} Track {this.m_To}";
        
        protected override GameObject GetFrom(Args args)
        {
            return this.m_From.Get(args);
        }

        protected override GameObject GetTo(Args args)
        {
            return this.m_To.Get(args);
        }
    }
}