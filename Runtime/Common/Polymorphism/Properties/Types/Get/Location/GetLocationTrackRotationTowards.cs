using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Rotation Towards")]
    [Category("Tracking/Rotation Towards")]
    
    [Image(typeof(IconEye), ColorTheme.Type.Green, typeof(BadgeArrowRight))]
    [Description("A rotation of the object towards the specified one")]
    
    [Get]
    
    [Serializable]
    public class TypeLocationTrackRotationTowards : TypeLocation
    {
        [SerializeField]
        private GetGameObject m_Towards = TypeGameObjectTarget.Create();

        public override Location Get(Args args)
        {
            Transform towards = this.m_Towards.Get<Transform>(args);

            return new Location(
                new PositionNone(),
                new RotationTowards(towards)
            );
        }
        
        public static GetLocation Create(GetGameObject towards)
        {
            return new GetLocation(new TypeLocationTrackRotationTowards
            {
                m_Towards = towards
            });
        }
        
        public override string ToString() => $"Towards {this.m_Towards}";
    }
}