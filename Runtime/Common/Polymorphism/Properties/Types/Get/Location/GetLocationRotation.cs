using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Rotation")]
    [Category("Constants/Rotation")]
    
    [Image(typeof(IconRotation), ColorTheme.Type.Yellow)]
    [Description("A single rotation without translation")]

    [Get]

    [Serializable]
    public class TypeLocationRotation : TypeLocation
    {
        [SerializeField]
        private GetQuaternion m_Rotation = new GetQuaternion(new TypeQuaternionRotationCharacter());

        public override Location Get(Args args)
        {
            return new Location(this.m_Rotation.Get(args));
        }

        public static GetLocation Create => new GetLocation(
            new TypeLocationRotation()
        );

        public override string ToString() => $"{this.m_Rotation}";
    }
}