using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Position")]
    [Category("Constants/Position")]

    [Image(typeof(IconVector3), ColorTheme.Type.Yellow)]
    [Description("A translation in space without rotation")]

    [Get]

    [Serializable]
    public class TypeLocationPosition : TypeLocation
    {
        [SerializeField]
        private GetVector3 m_Position = new GetVector3(new TypeVector3PositionCharacter());

        public override Location Get(Args args)
        {
            return new Location(this.m_Position.Get(args));
        }

        public static GetLocation Create => new GetLocation(
            new TypeLocationPosition()
        );

        public override string ToString() => this.m_Position.ToString();
    }
}