using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Location")]
    [Category("Constants/Location")]
    
    [Image(typeof(IconLocation), ColorTheme.Type.Yellow)]
    [Description("A translation and rotation in space")]

    [Get]

    [Serializable]
    public class TypeLocationPositionRotation : TypeLocation
    {
        [SerializeField]
        private GetVector3 m_Position = new GetVector3(new TypeVector3PositionCharacter());

        [SerializeField]
        private GetQuaternion m_Rotation = new GetQuaternion(new TypeQuaternionRotationCharacter());

        public override Location Get(Args args)
        {
            return new Location(
                this.m_Position.Get(args),
                this.m_Rotation.Get(args)
            );
        }
        
        public static GetLocation Create(GetVector3 pos, GetQuaternion rot)
        {
            return new GetLocation(new TypeLocationPositionRotation
            {
                m_Position = pos,
                m_Rotation = rot
            });
        }

        public override string ToString() => $"{this.m_Position} & {this.m_Rotation}";
    }
}