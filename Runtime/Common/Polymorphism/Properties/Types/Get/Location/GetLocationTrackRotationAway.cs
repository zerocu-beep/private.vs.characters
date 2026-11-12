using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Rotation Away")]
    [Category("Tracking/Rotation Away")]
    
    [Image(typeof(IconEye), ColorTheme.Type.Red, typeof(BadgeArrowLeft))]
    [Description("A rotation of the object away from the specified one")]
    
    [Get]
    
    [Serializable]
    public class TypeLocationTrackRotationAway : TypeLocation
    {
        [SerializeField]
        private GetGameObject m_AwayFrom = TypeGameObjectTarget.Create();

        public override Location Get(Args args)
        {
            Transform away = this.m_AwayFrom.Get<Transform>(args);
            
            return new Location(
                new PositionNone(),
                new RotationAway(away)
            );
        }
        
        public static GetLocation Create(GetGameObject away)
        {
            return new GetLocation(new TypeLocationTrackRotationAway
            {
                m_AwayFrom = away
            });
        }
        
        public override string ToString() => $"Away {this.m_AwayFrom}";
    }
}